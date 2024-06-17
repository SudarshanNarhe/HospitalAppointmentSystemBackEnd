using HospitalAppointmentSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointmentSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }  
        public DbSet<UserRole> Roles { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Specialty> Specility { get; set; }

        public DbSet<Doctors> Doctors { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Status> Status { get; set; }

        public DbSet<Appointment> Appointments { get; set; }
        
        public DbSet<HealthRecord> HealthRecords { get; set; }

        public DbSet<Prescriptions> Prescriptions { get; set; }
    }
}
