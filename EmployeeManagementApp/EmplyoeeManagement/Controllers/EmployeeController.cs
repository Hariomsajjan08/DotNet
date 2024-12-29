using Microsoft.AspNetCore.Mvc;
using Service;
using Models;

namespace EmplyoeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public IActionResult Index()
        {
            List<Employee> employees = employeeService.GetAllEmploye();
            this.ViewBag.Employees = employees;
            return View();
        }

        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            employeeService.AddEmployee(employee);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateEmployee() {
            return View();
        }
        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)
        {
            employeeService.UpdateEmployee(employee);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteEmployee(int Id)
        {
            employeeService.DeleteEmployee(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetEmployee(int Id)
        {
            Employee employee =employeeService.GetEmployee(Id);
            this.ViewBag.Employee = employee;
            return RedirectToAction("Index");
        }
    }
}
