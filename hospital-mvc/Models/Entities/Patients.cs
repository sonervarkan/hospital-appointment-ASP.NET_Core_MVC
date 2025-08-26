namespace hospital_mvc.Models.Entities
{
    public class Patients
    {
        public int Id { get; set; }
        public string? PatientName { get; set; }
        public string? PatientSurname { get; set; }
        public string? PatientTcNo { get; set; }
    }
}