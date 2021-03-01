using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SimpleApplicationTestingMvcSkills.Models;
using SimpleApplicationTestingMvcSkills.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SimpleApplicationTestingMvcSkills.Controllers
{
    public class WelcomeController : Controller
    {
        private IEmployeeRepo _empRepo;
        private IWebHostEnvironment _webHostEnvironment;
        public WelcomeController(IEmployeeRepo employeeRepo,
            IWebHostEnvironment webHostEnvironment)
        {
            _empRepo = employeeRepo;
            _webHostEnvironment = webHostEnvironment;

        }
        public ViewResult Programming()
        {
            ProgrammingIndexViewModel programmingIndexViewModel = new ProgrammingIndexViewModel()
            {
                Employees = _empRepo.GetListOfEmployees().ToList()
            };

            return View(programmingIndexViewModel);
        }
        public ViewResult Info(int? id)
        {
            Employee employee = _empRepo.GetEmployee(id.Value);
            if (employee == null)
            {
                Response.StatusCode = 404;
                ViewBag.Title = "404 Error";
                return View("EmployeeNotFound", id.Value);
            }

            WelcomeInfoViewModel welcomeInfoViewModel = new WelcomeInfoViewModel()
            {
                Employee = employee,
                PageTitle = "Employee Details"
            };
            return View(welcomeInfoViewModel);
        }
        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                ProcessFileToServer(model);

                _empRepo.Add(model);
                return RedirectToAction("info", new { id = model.ID });
            }
            return View();
        }
        //Edit Employee
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Employee employee = _empRepo.GetEmployee(id);
            if (employee == null)
            {
                Response.StatusCode = 404;
                ViewBag.Title = "404 Error";
                return View("EmployeeNotFound", id);
            }
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel()
            {
                ID = employee.ID,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhoto = employee.PhotoPath,
                PhotoPath = employee.PhotoPath
            };
            if (employee != null)
            {
                ViewBag.Title = "Edit Employee";
                return View(employeeEditViewModel);
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult Edit(EmployeeEditViewModel model)
        {
            Employee findPreviousEmp = _empRepo.GetEmployee(model.ID);
            if (findPreviousEmp != null)
            {
                if (model.Photo != null)
                {
                    if (model.ExistingPhoto != null)
                    {
                        var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", model.ExistingPhoto);
                        System.IO.File.Delete(path);
                    }

                    findPreviousEmp.PhotoPath = ProcessFileToServer(model);
                    //model.ExistingPhoto = null;
                    //model.Photo = null;
                }
                if (model.PhotoPath == null)
                {
                    model.PhotoPath = findPreviousEmp.PhotoPath;
                }
                _empRepo.Update(model);
                
                return RedirectToAction("info", new { id = model.ID });
            }
            return NotFound();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {

            Employee employee = _empRepo.GetEmployee(id);
            if (employee != null)
            {
                EmployeeDeleteViewModel model = new EmployeeDeleteViewModel()
                {
                    ID = employee.ID,
                    Name = employee.Name,
                    Email = employee.Email,
                    Department = employee.Department,
                    PhotoPath = employee.PhotoPath,
                    ExistingPhoto = employee.PhotoPath
                };

                return View(model);
            }


            return View("EmployeeNotFound", id);
        }
        public ActionResult Delete(EmployeeDeleteViewModel model)
        {
            Employee findPreviousEmp = _empRepo.GetEmployee(model.ID);
            if (findPreviousEmp != null)
            {
                if (findPreviousEmp.PhotoPath != null)
                {
                    //After Deleting the Image from the Database
                    _empRepo.Delete(findPreviousEmp.ID);
                    //Delete the Image form the Server
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", findPreviousEmp.PhotoPath);
                    System.IO.File.Delete(path);
                    return RedirectToAction("Programming", "Welcome");
                }

            }
            return View("EmployeeNotFound", model.ID);

        }
        private string ProcessFileToServer(EmployeeEditViewModel model)
        {
            //Process the Image on the Server
            string uniquFileName = null;
            if (model.Photo != null)
            {
                string fullPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniquFileName = Guid.NewGuid() + "_" + model.Photo.FileName;
                string combineFullPath = Path.Combine(fullPath, uniquFileName);
                using (var fileStream = new FileStream(combineFullPath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            model.PhotoPath = uniquFileName;
            return model.PhotoPath;
        }
        //Api Interface
        public List<Employee> XmlData()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    ID = 101,
                    Name = "Jimmy",
                    Email = "jimmy@gmail.com",
                    Department = HelperEnum.Department.Mgt
                },
                new Employee()
                {
                    ID = 102,
                    Name = "Patricia",
                    Email = "patricia@gmail.com",
                    Department = HelperEnum.Department.Finance
                },
                new Employee()
                {
                    ID = 103,
                    Name = "Alex",
                    Email = "alex@gmail.com",
                    Department = HelperEnum.Department.IT
                },
                new Employee()
                {
                    ID = 104,
                    Name = "Sharon",
                    Email = "sharon@gmail.com",
                    Department = HelperEnum.Department.HR
                }

            };
        }
        //Api Interface
        public JsonResult JsonData()
        {
            return Json(new Employee() { ID = 1, Name = "iamtuse", Department = HelperEnum.Department.IT, Email = "iamtuse@outlook.com" });
        }
        public ContentResult Text()
        {
            return Content("Hello World!", "application/txt");
        }
    }
}
