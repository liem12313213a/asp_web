using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace Project.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class GioHangController : Controller
    {
      
            private readonly ApplicationDbContext _db;

            public GioHangController(ApplicationDbContext db)
            {
                _db = db;
            }
        public IActionResult Index()
        {
            // Lay thong tin dang nhap
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);

            // Lấy danh sách sản phẩm trong giỏ hàng của user
            GioHangViewModel giohang = new GioHangViewModel
            {
                DsGioHang = _db.GioHang.Include("SanPham").Where(gh => gh.ApplicationUserId == claim.Value).ToList(),
                HoaDon = new HoaDon()
            };
            foreach(var item in giohang.DsGioHang)
            {
                //tinh tien theo so luong sp
                item.ProductPrice = item.Quantity * item.SanPham.Price;
                //tinh tong so tien
                giohang.HoaDon.Total += item.ProductPrice;
            }

            return View(giohang);
        }
        public IActionResult ThanhToan()
        {
            // Lấy thông tin tài khoản
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);

            // Lấy danh sách sản phẩm trong giỏ hàng của User
            GioHangViewModel giohang = new GioHangViewModel()
            {
                DsGioHang = _db.GioHang
                    .Include("SanPham")
                    .Where(gh => gh.ApplicationUserId == claim.Value)
                    .ToList(),
                HoaDon = new HoaDon()
            };

            // Tìm thông tin tài khoản trong CSDL để hiển thị lên trang thanh toán
            giohang.HoaDon.ApplicationUser = _db.ApplicationUser.FirstOrDefault(user => user.Id == claim.Value);

            // Gán thông tin tài khoản vào hóa đơn
            giohang.HoaDon.Name = giohang.HoaDon.ApplicationUser.Name;
            giohang.HoaDon.Address = giohang.HoaDon.ApplicationUser.Address;
            giohang.HoaDon.PhoneNumber = giohang.HoaDon.ApplicationUser.PhoneNumber;

            foreach (var item in giohang.DsGioHang)
            {
                // Tính tiền sản phẩm theo số lượng
                item.ProductPrice = item.Quantity * item.SanPham.Price;
                // Cộng dồn tổng số tiền trong giỏ hàng
                giohang.HoaDon.Total += item.ProductPrice;
            }

            return View(giohang);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult ThanhToan(GioHangViewModel giohang)
        {
            // Lay thong tin tai khoan
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);


            giohang.DsGioHang = _db.GioHang.Include("SanPham").Where(gh => gh.ApplicationUserId == claim.Value).ToList();

            giohang.HoaDon.ApplicationUserId = claim.Value;
            giohang.HoaDon.OrderDate = DateTime.Now;
            giohang.HoaDon.OrderStatus = "Đang xác nhận";

            foreach (var item in giohang.DsGioHang)
            {
                // Tính tien san pham theo so luong
                double prodcutprice = item.Quantity * item.SanPham.Price;
                giohang.HoaDon.Total += prodcutprice;
            }

            _db.HoaDon.Add(giohang.HoaDon);
            _db.SaveChanges();

            // Them thong tin chi tiet hoa don
            foreach (var item in giohang.DsGioHang)
            {
                ChiTietHoaDon chitiethoadon = new ChiTietHoaDon()
                {
                    SanPhamId = item.SanPhamId,
                    HoaDonId = giohang.HoaDon.Id,
                    ProductPrice = item.SanPham.Price * item.Quantity,
                    Quantity = item.Quantity
                };
                _db.ChiTietHoaDon.Add(chitiethoadon);
                _db.SaveChanges();

            }

            // Xoa thong tin trong gio hang
            _db.GioHang.RemoveRange(giohang.DsGioHang);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult xoa(int giohangId)
        {
            GioHang giohang = _db.GioHang.FirstOrDefault(gh => gh.Id == giohangId);
            //xoa gio hang
            _db.GioHang.Remove(giohang);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult tang(int giohangId)
        {
            GioHang giohang = _db.GioHang.FirstOrDefault(gh => gh.Id == giohangId);
            //tang 1
            giohang.Quantity += 1;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult giam(int giohangId)
        {
            GioHang giohang = _db.GioHang.FirstOrDefault(gh => gh.Id == giohangId);
            //giam 1
            giohang.Quantity -= 1;
            if(giohang.Quantity == 0)
            {
                _db.GioHang.Remove(giohang);
            }

            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
