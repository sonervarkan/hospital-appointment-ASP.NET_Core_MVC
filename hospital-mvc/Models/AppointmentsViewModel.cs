using hospital_mvc.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;       
using System.ComponentModel.DataAnnotations;    

namespace hospital_mvc.Models
{
    public class AppointmentsViewModel
    {
      
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Randevu tarihi zorunludur.")]
        public DateTime AppointmentDate { get; set; } 

        [Required(ErrorMessage = "Lütfen bir departman seçiniz.")]
        public int DepartmentId { get; set; } 

        [Required(ErrorMessage = "Lütfen bir doktor seçiniz.")]
        public int DoctorId { get; set; } 

        [Required(ErrorMessage = "Lütfen bir randevu saati seçiniz.")]
        public int TimeId { get; set; } 

       
        [Required(ErrorMessage = "Hasta adı zorunludur.")]
        public string? PatientName { get; set; } 

        [Required(ErrorMessage = "Hasta soyadı zorunludur.")]
        public string? PatientSurname { get; set; } 

        [Required(ErrorMessage = "TC Kimlik No zorunludur.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "TC Kimlik No 11 haneli olmalıdır.")]
        public string? PatientTcNo { get; set; } 

      
        public IEnumerable<SelectListItem>? Departments { get; set; }
        public IEnumerable<SelectListItem>? Doctors { get; set; }
        public IEnumerable<SelectListItem>? Times { get; set; }

   
        public List<Appointments>? Appointments { get; set; } 
    }
}