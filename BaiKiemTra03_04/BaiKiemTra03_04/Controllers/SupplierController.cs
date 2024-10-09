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

            IEnumerable<Supplier> supplier = _db.Supplier.Include("Order").ToList();
            return View(supplier);
        }
        [HttpGet]
        public IActionResult Upsert(int supplier_Id)
        {
            Supplier supplier = new Supplier();
            IEnumerable<SelectListItem> dsorder = _db.Supplier.Select(
                item => new SelectListItem
                {
                    Value = item.supplier_Id.ToString(),
                    Text = item.supplier_name
                });
            ViewBag.DSOrder = dsorder;

            if (supplier_Id == 0) // Create / Insert
            {
                return View(supplier);
            }
            else // Edit / Update
            {
                supplier = _db.Supplier.Include("Order").FirstOrDefault(sp => sp.supplier_Id == supplier_Id);
                return View(supplier);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                if (supplier.supplier_Id == 0)
                {
                    _db.Supplier.Add(supplier);
                }
                else
                {
                    _db.Supplier.Update(supplier);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int supplier_Id)
        {
            var supplier = _db.Supplier.FirstOrDefault(sp => sp.supplier_Id == supplier_Id);

            if (supplier == null)
            {
                return NotFound();
            }

            _db.Supplier.Remove(supplier);
            _db.SaveChanges();
            return Json(new { success = true });
        }
    }
}

