using hospital_mvc.Data;
using hospital_mvc.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace hospital_mvc.Controllers
{
    public class TimesController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public TimesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult list_time() 
        {
            var times = dbContext.times.ToList();
            return View(times);
        }


        [HttpGet]
        public IActionResult add_time()
        {
            return View();
        }

        [HttpPost]
        public IActionResult add_time(Times time)
        {
            if (ModelState.IsValid)
            {
                dbContext.times.Add(time);
                dbContext.SaveChanges();
                return RedirectToAction("list_time");       
            }
            return View(time);
        }
    }
}
