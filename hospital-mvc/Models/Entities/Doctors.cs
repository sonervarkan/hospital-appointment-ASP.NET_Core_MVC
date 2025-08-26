namespace hospital_mvc.Models.Entities
{
    public class Doctors
    {
        public int Id { get; set; }
        public string? DoctorNameSurname { get; set; }

        public int DepartmentId { get; set; }
        public Departments? Department { get; set; } 
    }
}