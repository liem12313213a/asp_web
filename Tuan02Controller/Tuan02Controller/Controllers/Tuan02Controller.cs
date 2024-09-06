using Microsoft.AspNetCore.Mvc;

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
        public ActionResult MayTinh(double a, double b, string pheptinh)
        {
            double result;
            switch (pheptinh)
            {
                case "cong":
                    result = a + b;
                    break;
                case "tru":
                    result = a - b;
                    break;
                case "nhan":
                    result = a * b;
                    break;
                case "chia":
                    if (b == 0) return Content("Không thể chia cho 0!");
                    result = a / b;
                    break;
                default:
                    return Content("Phép tính không hợp lệ!");
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
