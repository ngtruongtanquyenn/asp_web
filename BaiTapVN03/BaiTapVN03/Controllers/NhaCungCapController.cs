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
    }
}
