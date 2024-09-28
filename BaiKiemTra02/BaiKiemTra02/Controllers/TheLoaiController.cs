using BaiKiemTra02.Data;
using BaiKiemTraSo2.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTraSo2.Controllers
{
    public class TheLoaiController : Controller
    {
       
            private readonly ApplicationDbContext _db;
            public TheLoaiController(ApplicationDbContext db)
            {
                _db = db;
            }
            public IActionResult Index()
            {
                var lophoc = _db.LopHoc.ToList();
                ViewBag.lophoc = lophoc;
                return View();
            }
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create(LopHoc lophoc)
            {
                if (ModelState.IsValid)
                {
                    _db.LopHoc.Add(lophoc);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            [HttpGet]
            public IActionResult Edit(int id)
            {
                if (id == 0)
                {
                    return NotFound();
                }
                var lophoc = _db.LopHoc.Find(id);
                return View();
            }
            [HttpPost]
            public IActionResult Edit(LopHoc lophoc)
            {
                if (ModelState.IsValid)
                {
                    _db.LopHoc.Update(lophoc);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            [HttpGet]
            public IActionResult Delete(int id)
            {
                if (id == 0)
                {
                    return NotFound();
                }
                var lophoc = _db.LopHoc.Find(id);
                return View();
            }
            [HttpPost]
            public IActionResult DeleteConfirm(int id)
            {
                var lophoc = _db.LopHoc.Find(id);
                if (lophoc == null)
                {
                    return NotFound();
                }
                _db.LopHoc.Remove(lophoc);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            [HttpGet]
            public IActionResult Details(int id)
            {
                if (id == 0)
                {
                    return NotFound();
                }

                var lophoc = _db.LopHoc.Find(id);
                return View(lophoc);
            }
            [HttpGet]
            public IActionResult Search(String searchString)
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    var lophoc = _db.LopHoc.
                        Where(tl => tl.TenLopHoc.Contains(searchString)).ToList();
                    ViewBag.SearchString = searchString;
                    ViewBag.LopHoc = lophoc;
                }
                else
                {
                    var lophoc = _db.LopHoc.ToList();
                    ViewBag.LopHoc = lophoc;
                }
                return View("Index");
            }
        }
}


