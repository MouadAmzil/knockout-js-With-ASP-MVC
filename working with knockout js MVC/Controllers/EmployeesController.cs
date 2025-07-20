using Microsoft.AspNetCore.Mvc;
using working_with_knockout_js_MVC.Data;
using working_with_knockout_js_MVC.Models;

namespace working_with_knockout_js_MVC.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var data = _context.Employees.ToList();
            return Json(data);
        }

        [HttpPost]
        public JsonResult Create([FromBody] Employee emp)
        {
            _context.Employees.Add(emp);
            _context.SaveChanges();
            return Json(emp);
        }

        [HttpPost]
        public JsonResult Update([FromBody] Employee emp)
        {
            var existing = _context.Employees.FirstOrDefault(e => e.Id == emp.Id);
            if (existing != null)
            {
                existing.Name = emp.Name;
                existing.Department = emp.Department;
                existing.Age = emp.Age;
                _context.SaveChanges();
            }
            return Json(existing);
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var emp = _context.Employees.Find(id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
            return Json(emp);
        }
    }
}
