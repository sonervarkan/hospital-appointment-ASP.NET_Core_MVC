using Microsoft.EntityFrameworkCore;
using hospital_mvc.Models.Entities;

namespace hospital_mvc.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }

        public DbSet<Departments> departments { get; set; }
        public DbSet<Doctors> doctors { get; set; }
        public DbSet<Patients> patients { get; set; }
        public DbSet<Times> times { get; set; }
        public DbSet<Appointments> appointments { get; set; }
    }
}
