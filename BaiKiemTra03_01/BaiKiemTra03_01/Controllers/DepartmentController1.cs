using BaiKiemTra03_01.Data;
using BaiKiemTra03_01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra03_01.Controllers
{
    public class DepartmentController1 : Controller
    {
        private readonly ApplicationDbContext _db;

        public DepartmentController1(ApplicationDbContext context)
        {
            _db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _db.Departments.ToListAsync());
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentId,DepartmentName,NumberOfEmployees,ManagerId")] Department department)
        {
            if (ModelState.IsValid)
            {
                _db.Add(department);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
    }
}
