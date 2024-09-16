using BaiTap7a.Data;
using BaiTap7a.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap7a.Controllers
{
    public class TheLoaiController : Controller
    {
        private readonly ApplicationDbContext _db;
        public TheLoaiController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var theloai = _db.Loai.ToList();
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
            _db.Loai.Add(theloai);
            _db.SaveChanges();
            return View();
        }
    }
}
