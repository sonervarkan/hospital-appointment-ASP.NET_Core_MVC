using hospital_mvc.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

public class DoctorsViewModel
{
    public Doctors? DoctorOfVM { get; set; } 
    public IEnumerable<SelectListItem>? Departments { get; set; }
}