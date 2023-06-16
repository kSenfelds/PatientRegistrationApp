using Microsoft.EntityFrameworkCore;
using PatientRegistration.Core.Models;

namespace PatientRegistration.Database
{
    public class RegistrationDbContext: DbContext, IRegistrationDbContext
    {
        public RegistrationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
