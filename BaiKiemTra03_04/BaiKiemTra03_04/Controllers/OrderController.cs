using BaiKiemTra03_04.Data;
using BaiKiemTra03_04.Models;
using Microsoft.AspNetCore.Mvc;

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
                var order = _db.Order.ToList();
                ViewBag.order = order;
                return View();
            }
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public IActionResult Create(Order order)
            {
                if (ModelState.IsValid)
                {
                    _db.Order.Add(order);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            [HttpGet]
            public IActionResult Edit(int order_Id)
            {
                if (order_Id == 0)
                {
                    return NotFound();
                }
                var order = _db.Order.Find(order_Id);
                return View();
            }
            [HttpPost]
            public IActionResult Edit(Order order)
            {
                if (ModelState.IsValid)
                {
                    _db.Order.Update(order);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            [HttpGet]
            public IActionResult Delete(int order_Id)
            {
                if (order_Id == 0)
                {
                    return NotFound();
                }
                var order = _db.Order.Find(order_Id);
                return View();
            }
            [HttpPost]
            public IActionResult DeleteConfirm(int order_Id)
            {
                var order = _db.Order.Find(order_Id);
                if (order == null)
                {
                    return NotFound();
                }
                _db.Order.Remove(order);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            [HttpGet]
            public IActionResult Details(int order_Id)
            {
                if (order_Id == 0)
                {
                    return NotFound();
                }

                var order = _db.Order.Find(order_Id);
                return View(order);
            }
     }
}

