using BaiKiemTra02.Data;
using BaiKiemTra02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BaiKiemTra02.Controllers
{
    public class LopHocController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LopHocController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var lophoc = _db.lophoc.ToList();
            ViewBag.Lophoc = lophoc;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LopHoc lopHoc)
        {
            if (ModelState.IsValid)
            {
                _db.lophoc.Add(lopHoc);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Chỉnh sửa lớp học
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var lophoc = _db.lophoc.Find(id);
            return View(lophoc);
        }

        // POST: Chỉnh sửa lớp học
        [HttpPost]
        public IActionResult Edit(LopHoc lophoc)
        {
            if (ModelState.IsValid)
            {
                // Cập nhật thông tin lớp học
                _db.lophoc.Update(lophoc);
                // Lưu lại
                _db.SaveChanges();
                // Chuyển trang về index
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Xóa lớp học
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var lophoc = _db.lophoc.Find(id);
            return View(lophoc);
        }

        // POST: Xác nhận xóa lớp học
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            var lophoc = _db.lophoc.Find(id);
            if (lophoc == null)
            {
                return NotFound();
            }
            _db.lophoc.Remove(lophoc);
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
            var lophoc = _db.lophoc.Find(id);
            return View(lophoc);
        }

        //public IActionResult Search(string searchString)
        //{
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        // Sử dụng LINQ để tìm kiếm lớp học theo tên
        //        var LopHoc = _db.lophoc.Where(lh => lh.TenLopHoc.Contains(searchString)).ToList();
        //        ViewBag.SearchString = searchString;
        //        ViewBag.LopHoc = LopHoc;
        //    }
        //    else
        //    {
        //        var lophoc = _db.lophoc.ToList();
        //        ViewBag.LopHoc = lophoc;
        //    }
        //    return View("Index");
        //}

    }
}
