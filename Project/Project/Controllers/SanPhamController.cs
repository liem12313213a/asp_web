using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SanPhamController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SanPhamController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var sanpham = _db.SanPham
                .Include(s => s.TheLoai)
                .Include(s => s.NhaCungCap)
                .ToList();

            ViewBag.DSTheLoai = _db.TheLoai
                .Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.Id.ToString()
                })
                .ToList();

            ViewBag.DSNhaCungCap = _db.NhaCungCap
                .Select(n => new SelectListItem
                {
                    Text = n.Name,
                    Value = n.Id.ToString()
                })
                .ToList();

            return View(sanpham);
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            ViewBag.DSTheLoai = _db.TheLoai
                .Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.Id.ToString()
                })
                .ToList();

            ViewBag.DSNhaCungCap = _db.NhaCungCap
                .Select(n => new SelectListItem
                {
                    Text = n.Name,
                    Value = n.Id.ToString()
                })
                .ToList();
            if (id != null)
            {
                var sanPham = _db.SanPham
                    .Include(s => s.TheLoai)
                    .Include(s => s.NhaCungCap)
                    .FirstOrDefault(s => s.Id == id);

                if (sanPham == null)
                {
                    return NotFound();
                }

                return View(sanPham); 
            }

            return View(new SanPham()); 
        }

        [HttpPost]
        public IActionResult Upsert(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                if (sanPham.Id == 0)
                {
                    _db.SanPham.Add(sanPham);
                }
                else
                {
                    _db.Update(sanPham);
                }

                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DSTheLoai = _db.TheLoai
                .Select(t => new SelectListItem
                {
                    Text = t.Name,
                    Value = t.Id.ToString()
                })
                .ToList();

            ViewBag.DSNhaCungCap = _db.NhaCungCap
                .Select(n => new SelectListItem
                {
                    Text = n.Name,
                    Value = n.Id.ToString()
                })
                .ToList();

            return View(sanPham);
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = _db.SanPham.FirstOrDefault(s => s.Id == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            _db.SanPham.Remove(sanPham);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
       
    }
}