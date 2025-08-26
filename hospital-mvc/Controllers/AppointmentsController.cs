using hospital_mvc.Data;
using hospital_mvc.Models;
using hospital_mvc.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; 
using Microsoft.EntityFrameworkCore;


namespace hospital_mvc.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public AppointmentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult list_appointment()
        {
           
            var appointments = dbContext.appointments
                                       .Include(a => a.Patient)
                                       .Include(a => a.Doctor)
                                           .ThenInclude(d => d.Department) 
                                       .Include(a => a.Time)
                                       .ToList();

          
            var viewModel = new AppointmentsViewModel
            {
                Appointments = appointments
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult add_appointment()
        {
           
            var departments = dbContext.departments.ToList();
            var times = dbContext.times.ToList();

            var viewModel = new AppointmentsViewModel
            {
                Departments = new SelectList(departments, "Id", "DepartmentName"), 
                Doctors = new SelectList(new List<Doctors>(), "Id", "DoctorNameSurname"), 
                Times = new SelectList(times, "Id", "Hour") 
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult add_appointment(AppointmentsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                
                var newPatient = new Patients
                {
                    PatientName = viewModel.PatientName, 
                    PatientSurname = viewModel.PatientSurname, 
                    PatientTcNo = viewModel.PatientTcNo 
                };

                dbContext.patients.Add(newPatient);
                dbContext.SaveChanges();

            
                var newAppointment = new Appointments
                {
                    AppointmentDate = viewModel.AppointmentDate,
                    DoctorId = viewModel.DoctorId,
                    TimeId = viewModel.TimeId,
                    PatientId = newPatient.Id
                };

                dbContext.appointments.Add(newAppointment);
                dbContext.SaveChanges();

                return RedirectToAction("list_appointment");
            }

            
            var departments = dbContext.departments.ToList();
            viewModel.Departments = new SelectList(departments, "Id", "DepartmentName", viewModel.DepartmentId);

         
            var doctors = dbContext.doctors.Where(d => d.DepartmentId == viewModel.DepartmentId).ToList(); 
            viewModel.Doctors = new SelectList(doctors, "Id", "DoctorNameSurname", viewModel.DoctorId); 

            var times = dbContext.times.ToList();
            viewModel.Times = new SelectList(times, "Id", "Hour", viewModel.TimeId);

            return View(viewModel);
        }

        [HttpGet]
        public JsonResult GetDoctorsByDepartment(int departmentId)
        {
            var doctors = dbContext.doctors
                .Where(d => d.DepartmentId == departmentId) 
                .Select(d => new { id = d.Id, doctorNameSurname = d.DoctorNameSurname }) 
                .ToList();

            return Json(doctors);
        }


        [HttpGet]
        public JsonResult GetAvailableTimes(int doctorId, DateTime appointmentDate)
        {
            
            var occupiedTimeIds = dbContext.appointments
                                           .Where(a => a.DoctorId == doctorId && a.AppointmentDate.Date == appointmentDate.Date)
                                           .Select(a => a.TimeId)
                                           .ToList();

         
            var availableTimes = dbContext.times
                                          .Where(t => !occupiedTimeIds.Contains(t.Id))
                                          .Select(t => new { id = t.Id, hour = t.Hour })
                                          .ToList();

            return Json(availableTimes);
        }
    }
}