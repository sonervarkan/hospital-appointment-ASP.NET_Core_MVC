using hospital_mvc.Data;
using hospital_mvc.Models;
using hospital_mvc.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace hospital_mvc.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public DoctorsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult list_doctor()
        {
            var doctors = dbContext.doctors.Include(d => d.Department).ToList(); 
            return View(doctors);
        }

       

        [HttpGet]
        public IActionResult add_doctor()
        {
    
            var viewModel = new DoctorsViewModel
            {
      
                Departments = new SelectList(dbContext.departments, "Id", "DepartmentName")
            };
            return View(viewModel);
        }

 

        [HttpPost]
        public IActionResult add_doctor(DoctorsViewModel viewModel)
        {
            if (viewModel.DoctorOfVM != null)
            {
         
                dbContext.doctors.Add(viewModel.DoctorOfVM);
                dbContext.SaveChanges();
                return RedirectToAction("list_doctor");
            }

          
            viewModel.Departments = new SelectList(dbContext.departments, "Id", "DepartmentName"); 

            return View(viewModel);
        }

    }
}
