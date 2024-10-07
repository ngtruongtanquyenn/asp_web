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
            IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai").ToList();
            return View(sanpham);
        }

        [HttpGet]
        public IActionResult Upsert(int id)
        {
            SanPham sanpham = new SanPham();
            IEnumerable<SelectListItem> dstheloai = _db.Loai.Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name,
                }
                );
            ViewBag.DSTheLoai = dstheloai;
            if (id == 0)
            {
                return View(sanpham);
            }
            else
            {
                sanpham = _db.SanPham.Include("TheLoai").FirstOrDefault(sp => sp.Id == id);
                return View(sanpham);
            }
        }

        [HttpPost]
        public IActionResult Upsert(SanPham sanpham)
        {
            if (ModelState.IsValid)
            {
                if (sanpham.Id == 0)
                {
                    _db.SanPham.Add(sanpham);
                }

                else
                {
                    _db.SanPham.Update(sanpham);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult YourAction()
        {
            // Assuming you have a list of categories (the loai)
            var categories = new List<SelectListItem>
            {
        new SelectListItem { Value = "1", Text = "Category 1" },
        new SelectListItem { Value = "2", Text = "Category 2" },
        new SelectListItem { Value = "3", Text = "Category 3" }
            };

            ViewBag.DSTheLoai = new SelectList(categories, "Value", "Text");
            return View();
        }
    [HttpPost]
    public IActionResult Delete (int id)
    {
       var sanpham = _db.SanPham.FirstOrDefault(sp => sp.Id == id);
            if (sanpham == null)
            {
                return NotFound();
            }
            _db.SanPham.Remove(sanpham);
            _db.SaveChanges();
            return Json(new { success = true });
    }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var theloai = _db.Loai.Find(id);
            return View(theloai);
        }
    }

}
