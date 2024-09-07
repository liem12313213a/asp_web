using Microsoft.AspNetCore.Mvc;
using Tuan02Controller.Models;

namespace Tuan02Controller.Controllers
{
    public class Tuan02Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Huỳnh Thanh Liêm";
            ViewBag.MSSV = "1822031202";
            ViewData["Nam"] = "Năm 2024";
            return View();
        }
        public ActionResult MayTinh(string a, string b, string pheptinh)
        {
            bool kiemtra = true;
            if (!double.TryParse(a, out double A) || !double.TryParse(b, out double B))
            {
                ViewBag.Loi = "Vui lòng nhập a và b là số hợp lệ!";
                ViewBag.Kiemtra = false;
                return View("MayTinh");
            }

            double result;
            switch (pheptinh)
            {
                case "cong": 
                    result = A + B; 
                    break;
                case "tru": 
                    result = A - B; 
                    break;
                case "nhan": 
                    result = A * B; 
                    break;
                case "chia":
                    if (B == 0) 
                    { 
                        ViewBag.Loi = "Không thể chia cho 0!";
                        kiemtra = false;
                        ViewBag.kiemtra = kiemtra;
                        return View("MayTinh"); 
                    }
                    result = A / B; 
                    break;
                default: ViewBag.Loi = "Phép tính không hợp lệ!";
                kiemtra = false;
                    ViewBag.kiemtra = kiemtra;
                    return View("MayTinh");
            }

            ViewBag.Result = result;
            return View("MayTinh");
        }
        public ActionResult Profile()
        {
            return View("Profile");
        }

    }
}
