using ComapnyWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using ComapnyWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection.Emit;
using System.Net;

namespace ComapnyWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly CompanyDbContext _context;
        public AdminController(CompanyDbContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region Department

        [HttpGet]
        public IActionResult Department()
        {
            Department department = new Department();
            department.AllDepartment = _context.Departments.ToList();
            return View(department);
        }

        [HttpPost]
        public async Task<IActionResult> Department(Department model)
        {
            //    if (ModelState.IsValid)
            //{
                var IsAlreadyExist = _context.Departments.Any(e => e.DeptName.ToLower() == model.DeptName.ToLower());

                if (!IsAlreadyExist)
                {
                    _context.Departments.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Department");
                }
            //    ModelState.AddModelError("", "This Department is Already Existed.");

            //}
            return View(model);
        }

        // GET: EditDepartment
        //[HttpGet]
        //public IActionResult EditDepartment(int? Id)
        //{
        //    var department = _context.Departments.FirstOrDefault(e => e.Id == Id);

        //    if (department == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(department);
        //}

        // POST: EditDepartment
            [HttpPost]
            public JsonResult EditDepartment(Department model) 
            {
            try
            {
                string message = string.Empty;
                var department = _context.Departments.FirstOrDefault(e => e.Id == model.Id);
                if (department != null)
                {
                    department.DeptName = model.DeptName;
                    _context.Departments.Update(department);
                    message = "Updated";
                }
                else
                {
                    _context.Departments.Add(model);
                    message = "Added";
                }
                _context.SaveChanges();
                return Json(new { status = true, message = $"Department {message} successfully!" });

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = "An error occurred while updating the department." });
            }
            }

        //[HttpGet]
        //public IActionResult DeleteDepartment(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var department = _context.Departments.FirstOrDefault(e => e.Id == id);

        //    if (department == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(department);
        //}

        [HttpPost]
        public JsonResult DeleteDepartment(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}
            
            var DepartmentToRemove = _context.Departments.FirstOrDefault(e => e.Id == id);
            
            if (DepartmentToRemove != null)
            {
                _context.Departments.Remove(DepartmentToRemove);
                _context.SaveChanges();
            }


            return Json(new { status = true, message = "Department deleted successfully!" }); 

        }

        #endregion

        #region City

        [HttpGet]
        public IActionResult AddCity()
        {
            City city = new City();
            city.AllCities = _context.Cities.ToList();
            ViewBag.States = _context.States.ToList();
            return View(city);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(City model)
        {
            //if (ModelState.IsValid)
            //{
                var IsCityExist = _context.Cities.Any(e => e.CityName.ToLower() == model.CityName.ToLower());
                if (!IsCityExist)
                {
                    _context.Cities.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("AddCity");
                }
                //ModelState.AddModelError("", "This City is Already Existed.");
            //}
            return RedirectToAction("AddCity");
        }

        // GET: EditCity
        [HttpGet]
        public IActionResult EditCity(int? Id)
        {
            var city = _context.Cities.FirstOrDefault(e => e.CityId == Id);
            ViewBag.States = _context.States.ToList();
           

            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: EditCity
        [HttpPost]
        public IActionResult EditCity(City city)
        {
            try
            {
                _context.Cities.Update(city);
                _context.SaveChanges();
                return RedirectToAction("AddCity");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Get: DeleteCity
        [HttpGet]

        public IActionResult DeleteCity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = _context.Cities.FirstOrDefault(e => e.CityId == id);

            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        [HttpPost]
        public IActionResult CDeleteCity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityR = _context.Cities.FirstOrDefault(e => e.CityId == id);

            if (cityR != null)
            {
                _context.Cities.Remove(cityR);
                _context.SaveChanges();           
            }
            return RedirectToAction("AddCity");
        }



        #endregion

        #region State

        [HttpGet]
        public IActionResult AddState()
        {
            
            States states = new States();
            states.AllStates = _context.States.ToList();
            return View(states);
        }

        [HttpPost]
        public async Task<IActionResult> AddState(States model)
        {
            if (ModelState.IsValid)
            {
                var IsStateExist = _context.States.Any(e => e.StateName.ToLower() == model.StateName.ToLower());
                if (!IsStateExist)
                {
                    _context.States.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }               
                ModelState.AddModelError("", "This State is Already Existed.");
            }
            return View(model);
        }


        [HttpGet]

        public IActionResult EditState(int? Id)
        {
            var state = _context.States.FirstOrDefault(e => e.StateId == Id);


            if (state == null)
            {
                return NotFound();
            }

            return View(state);
        }

        



        #endregion

   }
}
