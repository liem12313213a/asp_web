using BaiKiemTra03_04.Data;
using BaiKiemTra03_04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra03_04.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()

        {
            IEnumerable<Order> orders = _db.Order.Include("Suplier").ToList();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Upsert(int order_Id)
        {
            Order order;
            IEnumerable<SelectListItem> dsSuppliers;

            if (order_Id == 0) // Create
            {
                order = new Order();
                dsSuppliers = _db.Supplier.Select(s => new SelectListItem
                {
                    Value = s.supplier_Id.ToString(),
                    Text = s.supplier_name
                });
            }
            else // Edit
            {
                order = _db.Order.Include(o => o.Supplier).FirstOrDefault(o => o.order_Id == order_Id);
                dsSuppliers = _db.Supplier.Select(s => new SelectListItem
                {
                    Value = s.supplier_Id.ToString(),
                    Text = s.supplier_name
                });

                if (order == null)
                {
                    return NotFound();
                }
            }

            ViewBag.DSSuppliers = dsSuppliers;
            return View(order);
        }

        [HttpPost]
        public IActionResult Upsert(Order order)
        {
            if (ModelState.IsValid)
            {
                if (order.order_Id == 0)
                {
                    _db.Order.Add(order);
                }
                else
                {
                    _db.Order.Update(order);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Repopulate dropdown list if validation fails
            IEnumerable<SelectListItem> dsSuppliers = _db.Supplier.Select(s => new SelectListItem
            {
                Value = s.supplier_Id.ToString(),
                Text = s.supplier_name
            });
            ViewBag.DSSuppliers = dsSuppliers;
            return View(order);
        }

        [HttpPost]
        public IActionResult Delete(int order_Id)
        {
            var order = _db.Order.Find(order_Id);
            if (order == null)
            {
                return NotFound();
            }

            _db.Order.Remove(order);
            _db.SaveChanges();
            return Json(new { success = true });
        }
    }
}

