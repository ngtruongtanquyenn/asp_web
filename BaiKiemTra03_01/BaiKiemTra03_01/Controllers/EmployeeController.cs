using BaiKiemTra03_01.Data;
using BaiKiemTra03_01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult Index()
        {
            IEnumerable<Employee> employee = _db.Employees.Include("Department").ToList();
            return View(employee);
        }



        [HttpGet]
        public IActionResult Upsert(int id)
        {
            IEnumerable<SelectListItem> dsdepartment= _db.Departments.Select(
                item => new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                }
            );
            ViewBag.DSDepartment = dsdepartment;

            Employee employee;

            if (id == 0)
            {
                employee = new Employee();
            }
            else
            {
                employee = _db.Employees.Include("Department").FirstOrDefault(sp => sp.EmployeeId == id);
                if (employee == null)
                {
                    return NotFound(); // Xử lý nếu sản phẩm không tồn tại
                }
            }

            return View(employee);
        }
        [HttpPost]
        public IActionResult Upsert(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.EmployeeId == 0)
                {
                    _db.Employees.Add(employee);
                }
                else
                {
                    _db.Employees.Update(employee);
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employee = _db.Employees.FirstOrDefault(sp => sp.EmployeeId == id);
            if (employee == null)
            { return NotFound(); }
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return Json(new { success = true });
        }
    }
}

