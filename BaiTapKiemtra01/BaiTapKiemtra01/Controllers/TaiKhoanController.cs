using BaiTapKiemtra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemtra01.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult DangKy(TaiKhoanViewModel model)
        {
            if (!string.IsNullOrEmpty(model.Username) && !string.IsNullOrEmpty(model.Password)
                && !string.IsNullOrEmpty(model.Name) && model.Old > 0)
            {
                string message = $"Tên tài khoản: {model.Username}, Mật khẩu: {model.Password}, Họ tên: {model.Name}, Tuổi: {model.Old}";
                return Content(message);
            }
            return View();
        }

    }
}
