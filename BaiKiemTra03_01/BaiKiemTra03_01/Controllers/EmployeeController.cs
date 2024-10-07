using BaiKiemTra03_01.Data;
using BaiKiemTra03_01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra03_01.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var employees = await _db.Employees.Include(e => e.Department).ToListAsync();
            return View(employees);
        }

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
