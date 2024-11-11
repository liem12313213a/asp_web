using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NhaCungCapController : Controller
    {
        private readonly ApplicationDbContext _db;

        public NhaCungCapController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string searchString)
        {
            IEnumerable<NhaCungCap> nhaCungCap;
            if (!string.IsNullOrEmpty(searchString))
            {
                nhaCungCap = _db.NhaCungCap.Where(tl => tl.Name.Contains(searchString)).ToList();
                ViewBag.SearchString = searchString;
            }
            else
            {
                nhaCungCap = _db.NhaCungCap.ToList();
            }
            return View(nhaCungCap);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(NhaCungCap nhaCungCap)
        {
            if (ModelState.IsValid)
            {
                _db.NhaCungCap.Add(nhaCungCap);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhaCungCap);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var nhaCungCap = _db.NhaCungCap.Find(id);

            return View(nhaCungCap);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var nhaCungCap = _db.NhaCungCap.Find(id);

            return View(nhaCungCap);
        }

        [HttpPost]
        public IActionResult Edit(NhaCungCap nhaCungCap)
        {
            if (ModelState.IsValid)
            {
                _db.NhaCungCap.Update(nhaCungCap);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhaCungCap);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var nhaCungCap = _db.NhaCungCap.Find(id);

            return View(nhaCungCap);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var nhaCungCap = _db.NhaCungCap.Find(id);
            if (nhaCungCap == null)
            {
                return NotFound();
            }
            _db.NhaCungCap.Remove(nhaCungCap);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}