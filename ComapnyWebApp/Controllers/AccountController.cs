using ComapnyWebApp.Data;
using ComapnyWebApp.Models;
//using ComapnyWebApp.StaticData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;
using ComapnyWebApp.Utilities;

namespace ComapnyWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly CompanyDbContext _context;
        public AccountController(CompanyDbContext context)
        {
            _context = context; 
            
        }
        public IActionResult Index()
        {
            //return View();
            //var allEmployees = EmployeeData.GetAllEmployees();
            //return View(allEmployees);

            var allEmployees = _context.Employees.ToList()  ;
            return View(allEmployees);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Hash the provided password
                string hashedPassword = PasswordHasher.HashPassword(model.Password);

                // Check if there's a user with the provided EmployeeCode and hashed password
                var user = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeCode == model.EmployeeCode && e.Password == hashedPassword);

                if (user != null)
                {
                    // Authentication successful                     
                    return RedirectToAction("Index");
                }

                // Authentication failed
              ModelState.AddModelError("", "Invalid EmployeeCode or Password");
            }

            // If ModelState is not valid, return to the login view with error messages
            return View(model);
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration([Bind("EmployeeCode", "FirstName", "LastName", "Email", "Mobile", "Gender", "DOB", "Password", "ConfirmPassword")] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    //EmployeeData.AddEmployee(employee);
                    ////var allEmployees = EmployeeData.GetAllEmployees();
                    //return RedirectToAction("Index");
                    employee.Password = PasswordHasher.HashPassword(employee.Password);
                    employee.ConfirmPassword = PasswordHasher.HashPassword(employee.ConfirmPassword);

                    _context.Employees.Add(employee);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                    //return Json(EmployeeData._lstEmployee);
                }

            }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists " +
                        "see your system administrator.");
                }
                return View("Registration", employee);
                //return View(employee);
        }

        // GET: Employees/Edit
        [HttpGet]
        public IActionResult Edit(string? empCode)
        {
            if (string.IsNullOrEmpty(empCode))
            {
                return NotFound();
            }

            //var employee = EmployeeData.GetEmployeeById(id);
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeCode == empCode);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee employee)
        {
           
            try
            {
                //EmployeeData.UpdateEmployee(employee);
                _context.Employees.Update(employee);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
                //ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                //return View(employee);
            }
        }

        [HttpGet]
        public IActionResult Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var employee = EmployeeData.GetEmployeeById(id);
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeCode == id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string? id)
        {
           if (id == null)
            {
                return NotFound();
            }

            var employeeToRemove = _context.Employees.FirstOrDefault(e => e.EmployeeCode == id);

            if (employeeToRemove != null)
            {
                _context.Employees.Remove(employeeToRemove);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
