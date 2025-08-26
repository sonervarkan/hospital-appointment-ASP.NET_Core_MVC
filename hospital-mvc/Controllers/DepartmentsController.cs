using hospital_mvc.Data;
using hospital_mvc.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace hospital_mvc.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public DepartmentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult list_department()
        {
            var departments = dbContext.departments.ToList();
            return View(departments);
        }


        [HttpGet]
        public IActionResult add_department() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult add_department(Departments department) 
        {
            if (ModelState.IsValid) 
            {
                dbContext.departments.Add(department);
                dbContext.SaveChanges();

                return RedirectToAction("list_department");
            }

            return View(department);

        }
    }
}
