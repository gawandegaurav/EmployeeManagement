using System;
using System.IO;
using EmployeeManagement.DataAccess;
using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    //[Route("EmployeeHome")]
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _repository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IEmployeeRepository repository, IHostingEnvironment hostingEnvironment)
        {
            _repository = repository;
            _hostingEnvironment = hostingEnvironment;
        }

        //[Route("")]
        //[Route("EmployeeHome")]
        //[Route("EmployeeHome/GetAll")]
        //[Route("[action]")]
        public ViewResult Index()
        {
            var model = _repository.Read();
            return View(model);
        }

        //[Route("GetEmployee/{id?}")]
        //[Route("[action]/{id?}")]
        public ViewResult Details(int? id)
        {
            var employee = _repository.GetEmployee(id ?? 1);
            var model = new EmployeeDetailsViewModel { Employee = employee, PageTitle = "Employee Details" };
            return View(model);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    uniqueFileName = ProcessFile(model);
                }

                var employee = new Employee
                {
                    Name = model.Name,
                    Department = model.Department,
                    Email = model.Email,
                    PhotoPath = uniqueFileName
                };

                var newEmployee = _repository.Create(employee);

                return RedirectToAction("Details", new { id = newEmployee.Id });
            }

            return View();
        }

        [HttpGet]
        public ViewResult Edit(int Id)
        {
            var employee = _repository.GetEmployee(Id);
            var employeeEditViewModel = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                ExistingPhotoPath = employee.PhotoPath,
                Name = employee.Name,
                Department = employee.Department,
                Email = employee.Email
            };
            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingEmployee = _repository.GetEmployee(model.Id);
                existingEmployee.Name = model.Name;
                existingEmployee.Department = model.Department;
                existingEmployee.Email = model.Email;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(path);
                    }
                    string uniqueFileName = ProcessFile(model);
                    existingEmployee.PhotoPath = uniqueFileName;
                }

                var newEmployee = _repository.Update(existingEmployee);

                return RedirectToAction("Index");
            }

            return View();
        }

        private string ProcessFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid() + "_" + model.Photo.FileName;
                var filePath = Path.Combine(uploadFolder, uniqueFileName);
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}