using Microsoft.AspNetCore.Mvc;

namespace BaiTapVN02.Controllers
{
    public class Tuan02Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Nguyễn Trương Tấn Quyền";
            ViewBag.MSSV = "1822040819";
            ViewData["Nam"] = "2023";
            return View();
        }

        public IActionResult MayTinh(double a, double b, string PhepTinh)
        {
            double ketqua = 0;
            switch(PhepTinh)
            {
                case "cong":
                    ketqua = a + b;
                    break;
                case "tru":
                    ketqua = a - b;
                    break;
                case "nhan":
                    ketqua = a * b;
                    break;
                case "chia":
                    if (b != 0)
                    {
                        ketqua = a / b;
                    }
                     
                    else
                    {
                        ViewBag.Loi = "Không thể chia cho 0";
                    }
                    break;
                    default:
                    ViewBag.Loi = "Phép tính không hợp lệ";
                    break;
            }
            ViewBag.ketqua = ketqua;
            return View();
        }

        public IActionResult Profile()
        { 
            
            return View(); 
        }
    }
}
