using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Project.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<SanPham> sanpham = _db.SanPham.Include(sp => sp.TheLoai).Include(sp => sp.NhaCungCap).ToList();
            return View(sanpham);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Details(int sanphamid)
        {
            GioHang giohang = new GioHang()
            {
                SanPhamId = sanphamid,
                SanPham = _db.SanPham.Include("TheLoai").Include("NhaCungCap").FirstOrDefault(sp => sp.Id == sanphamid),
                Quantity = 1
            };
            return View(giohang);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(GioHang giohang)
        {
            // Lấy thông tin đăng nhập
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);

            giohang.ApplicationUserId = claim.Value;

            // Kiểm tra sản phẩm đã có trong giỏ hàng chưa
            var giohangdb = _db.GioHang.FirstOrDefault(sp => sp.SanPhamId == giohang.SanPhamId && sp.ApplicationUserId == giohang.ApplicationUserId);
            if (giohangdb == null)
            {
                _db.GioHang.Add(giohang);
            }
            else
            {
                giohangdb.Quantity += giohang.Quantity;
            }

            // Lưu xuống cơ sở dữ liệu
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult FilterByTheLoai(int id)
        {
            IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai").Include("NhaCungCap").Where(s => s.TheLoai.Id == id).ToList();
            return View("Index", sanpham);
        }
        [HttpGet]
        public IActionResult Search(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var sanpham = _db.SanPham.Where(tl => tl.Name.Contains(searchString)).ToList();
                ViewBag.SearchString = searchString;
                ViewBag.SanPham = sanpham;
            }
            else
            {
                var sanpham = _db.SanPham.ToList();
                ViewBag.SanPham = sanpham;
            }
            return View("Index", ViewBag.SanPham); // Using "Index" for the search result
        }
   }
}