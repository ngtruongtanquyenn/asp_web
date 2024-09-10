using BaiTapKiemtra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemtra01.Controllers
{
    public class SanPhamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SanPham()
        {
            var sanpham = new SanPhamViewModel()
            {
                TenSanPham = "Rùa Aligator Slapping",
                GiaBan = 4000000, 
                AnhMoTa = "/images/1.jfif"
            };

            return View(sanpham);
        }

    }
}
