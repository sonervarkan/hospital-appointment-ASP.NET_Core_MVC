namespace hospital_mvc.Models.Entities
{
    public class Departments
    {
        public int Id { get; set; }
        public string? DepartmentName { get; set; }

       
        public ICollection<Doctors> Doctors { get; set; } = new List<Doctors>();
    }
}