using BaiTapVN03.Data;
using BaiTapVN03.Models;
using Microsoft.AspNetCore.Mvc;


namespace BaiTapVN03.Controllers
{
    public class NhaCungCapController : Controller
    {
        public readonly ApplicationDbContext _cc;

        public NhaCungCapController(ApplicationDbContext cc)
        {
            _cc = cc;
        }
        public IActionResult Index()
        {
            var cungcap = _cc.NhaCungCaps.ToList();
            ViewBag.Cungcap = cungcap;
            return View();
        }

        [HttpGet]
        public IActionResult Them()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Them(NhaCungCap cungcap)
        {
            if (ModelState.IsValid)
            {
                _cc.NhaCungCaps.Add(cungcap);
                _cc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //[HttpPost]
        //public ActionResult Them(NhaCungCap cungcap, IFormFile file)
        //{
        //    if (file != null && file.Length > 0)
        //    {
        //        var fileName = Path.GetFileName(file.FileName);
        //        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

        //        // Lưu file vào đường dẫn trên server
        //        using (var stream = new FileStream(path, FileMode.Create))
        //        {
        //            file.CopyTo(stream);
        //        }

        //        // Lưu đường dẫn ảnh 
        //        cungcap.ImageUrl = "/images/" + fileName;
        //    }
        //    _cc.NhaCungCaps.Add(cungcap);  // db là context của database
        //    _cc.SaveChanges();
        //    return View();
        //}
    }
}
