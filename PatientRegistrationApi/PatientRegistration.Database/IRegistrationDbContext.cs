using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PatientRegistration.Core.Models;

namespace PatientRegistration.Database
{
    public interface IRegistrationDbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public int SaveChanges();

        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
    }
}