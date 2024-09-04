using BaiTap05.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BaiTap05.Controllers
{
    public class TheLoaiController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Ngay = "Ngày 04";
            ViewBag.Thang = "Tháng 09";
            ViewData["Nam"] = "Năm 2024";
            return View();
        }
        public IActionResult Index2()
        {
            var theloai = new TheLoaiViewModel
            {
                Id = 1,
                Name = "Trinh thám"
            };
            return View(theloai);
        }
        
    }
}
