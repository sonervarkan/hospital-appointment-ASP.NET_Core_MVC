namespace hospital_mvc.Models.Entities
{
    public class Appointments
    {
        public int Id { get; set; }

        public DateTime AppointmentDate { get; set; }


        public int DoctorId { get; set; }
        public Doctors? Doctor { get; set; } 

        public int TimeId { get; set; }
        public Times? Time { get; set; } 

        public int PatientId { get; set; }
        public Patients? Patient { get; set; }
    }
}