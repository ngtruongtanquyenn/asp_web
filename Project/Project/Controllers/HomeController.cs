using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using System.Diagnostics;

namespace Project.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger , ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<SanPham> sanpham = _db.SanPham.Include("TheLoai").ToList();
            return View(sanpham);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Details(int id) 
        {
            SanPham sanpham = new SanPham();

            sanpham = _db.SanPham.Include("TheLoai").FirstOrDefault(sp => sp.Id == id);
            return View(sanpham);
            
        }
        [HttpGet]
        public IActionResult FilterByTheLoai(int id)
        {
            
            var sanpham = _db.SanPham
                     .Include("TheLoai")  // Include bằng Lambda Expression
                     .Where(sp => sp.TheLoaiId == id)  // Sử dụng TheLoaiId
                     .ToList();

            return View("Index", sanpham);
        }
    }
}
