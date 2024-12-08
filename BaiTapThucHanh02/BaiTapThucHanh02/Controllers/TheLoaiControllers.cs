﻿using BaiTapThucHanh02.Models;
using BaiTapThucHanh02.Data;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapThucHanh02.Controllers
{
    public class TheLoaiControllers : Controller
    {
        private readonly ApplicationDbContext _db;
        public TheLoaiControllers(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var theloai = _db.TheLoai.Where(t => t.Id > 2).ToList();
            ViewBag.TheLoai = theloai;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {
                _db.TheLoai.Add(theloai);
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
            var theloai = _db.TheLoai.Find(id);
            return View();
        }
        [HttpPost]
        public IActionResult Edit(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {
                _db.TheLoai.Update(theloai);
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
            var theloai = _db.TheLoai.Find(id);
            return View();
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var theloai = _db.TheLoai.Find(id);
            if (theloai == null)
            {
                return NotFound();
            }
            _db.TheLoai.Remove(theloai);
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

            var theloai = _db.TheLoai.Find(id);
            if (theloai == null)
            {
                return NotFound();
            }

            return View(theloai);
        }
        [HttpPost]
        public IActionResult Details(TheLoai theloai)
        {
            if (ModelState.IsValid)
            {
                _db.TheLoai.Update(theloai);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theloai);
        }
        [HttpGet]
        public IActionResult Search(String searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                var theloai = _db.TheLoai.
                    Where(tl=>tl.Name.Contains(searchString)).ToList();
                ViewBag.SearchString = searchString;
                ViewBag.TheLoai = theloai;
            }
            else
            {
                var theloai = _db.TheLoai.ToList();
                ViewBag.TheLoai = theloai;
            }

            return View("Index");

        }
    }
}

