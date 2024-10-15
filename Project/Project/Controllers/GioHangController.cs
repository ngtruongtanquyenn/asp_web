using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using System.Security.Claims;

namespace Project.Controllers
{
    [Area("Customer")]
    public class GioHangController : Controller
    {
        public readonly ApplicationDbContext _db;
        public GioHangController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //Lay thong tin tai khoan
            var identity = (ClaimsIdentity)User.Identity;
            var claim = identity.FindFirst(ClaimTypes.NameIdentifier);
            
            //lay danh sach cac san pham trong gio hang User
            IEnumerable<GioHang> dsGioHang = _db.GioHang.Include("SanPham").Where(gh => gh.ApplicationUserId == claim.Value).ToList();
            return View(dsGioHang);
        }
    }
}
