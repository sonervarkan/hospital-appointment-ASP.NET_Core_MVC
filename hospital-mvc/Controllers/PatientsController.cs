using hospital_mvc.Data;
using Microsoft.AspNetCore.Mvc;
using hospital_mvc.Models.Entities;

namespace hospital_mvc.Controllers
{
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public PatientsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult list_patient()
        {
            var patients = dbContext.patients.ToList();
            return View(patients);
        }

        [HttpGet]
        public IActionResult add_patient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult add_patient(Patients patient) 
        {
            if (ModelState.IsValid)
            {
                dbContext.patients.Add(patient);
                dbContext.SaveChanges();
                return RedirectToAction("list_patient");

            }

            return View(patient);
            
        }
    }
}
