using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra01.Controllers
{
    public class Theloai : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DangKy(TaiKhoanViewModel taiKhoan)
        {
            if (taiKhoan != null && taiKhoan.Password != null && taiKhoan.Password.Length > 0)
            {
                taiKhoan.Password = taiKhoan.Password + "_da_ma_hoa";
            }
            return View(taiKhoan);
        }
        public IActionResult BaiTap2()
        {
        var sanPhamList = new List<SanPhamViewModel>
        {
        new SanPhamViewModel
        {
            TenSanPham = "Sản phẩm 1",
            GiaBan = 100000,
            Anhmota = "~/wwwrot/img/1.png" 
        },
        new SanPhamViewModel
        {
            TenSanPham = "Sản phẩm 2",
            GiaBan = 200000,
            Anhmota = "~/wwwrot/img/2.png"
        },
        new SanPhamViewModel
        {
            TenSanPham = "Sản phẩm 3",
            GiaBan = 300000,
            Anhmota = "~/wwwrot/images/3.png"
        },
        new SanPhamViewModel
        {
            TenSanPham = "Sản phẩm 4",
            GiaBan = 400000,
            Anhmota = "/wwwrot/img/4.png"
        },
        new SanPhamViewModel
        {
            TenSanPham = "Sản phẩm 5",
            GiaBan = 500000,
            Anhmota = "~/wwwrot/img/5.png"
        }
        };

            return View(sanPhamList);
        }
    }
}
