using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
   // [Route("EmployeeHome")]
    //[Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _repository;

        public HomeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        [Route("")]
        [Route("EmployeeHome")] 
        [Route("EmployeeHome/GetAll")]
        //[Route("[action]")]
        public ViewResult Index()
        {
            var model = _repository.GetEmployees();
            return View(model);
        }

      //  [Route("GetEmployee/{id?}")]
       // [Route("[action]/{id?}")]
        public ViewResult Details(int? id)
        {
            var employee = _repository.GetEmployee(id??1);
            var model = new EmployeeDetailsViewModel { Employee = employee, PageTitle = "Employee Details" };
            return View(model);
        }
    }
}