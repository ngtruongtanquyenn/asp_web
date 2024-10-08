using BaiKiemTra03_01.Data;
using BaiKiemTra03_01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BaiKiemTra03_01.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DepartmentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var departments = _db.Departments.ToList();
            ViewBag.Department = departments;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.Departments.Add(department);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
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
            var department = _db.Departments.Find(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                // Thêm thông tin vào bảng TheLoai
                _db.Departments.Update(department);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
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
            var department = _db.Departments.Find(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var department = _db.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }
            _db.Departments.Remove(department);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var department = _db.Departments.Find(id);
            return View(department);
        }

    }
}
