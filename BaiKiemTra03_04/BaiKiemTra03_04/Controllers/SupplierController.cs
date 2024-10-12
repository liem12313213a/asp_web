using BaiKiemTra03_04.Data;
using BaiKiemTra03_04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra03_04.Controllers
{

public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SupplierController(ApplicationDbContext db)

        {
            _db = db;
        }

        public IActionResult Index()
        {
            var suppliers = _db.Supplier.ToList();
            ViewBag.Suppliers = suppliers;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)

            {
                _db.Supplier.Add(supplier);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
            // Re-render view with validation errors
        }

        [HttpGet]
        public IActionResult Edit(int supplier_Id)
        {
            if (supplier_Id == 0)
            {
                return NotFound();
            }

            var supplier = _db.Supplier.Find(supplier_Id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _db.Supplier.Update(supplier);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier); // Re-render view with validation errors
        }

        [HttpGet]
        public IActionResult Delete(int supplier_Id)
        {
            if (supplier_Id == 0)
            {
                return NotFound();
            }

            var supplier = _db.Supplier.Find(supplier_Id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int supplier_Id)
        {
            var supplier = _db.Supplier.Find(supplier_Id);
            if (supplier == null)
            {
                return NotFound();
            }

            _db.Supplier.Remove(supplier);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int supplier_Id)
        {
            if (supplier_Id == 0)
            {
                return NotFound();
            }

            var supplier = _db.Supplier.Find(supplier_Id);
            if (supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        [HttpGet]
        public IActionResult Search(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var suppliers = _db.Supplier
                    .Where(s => s.supplier_name!.Contains(searchString))
                    .ToList();
                ViewBag.SearchString = searchString;
                ViewBag.Suppliers = suppliers;
            }
            else
            {
                var suppliers = _db.Supplier.ToList();
                ViewBag.Suppliers = suppliers;
            }
            return View("Index");
        }
    }
}

