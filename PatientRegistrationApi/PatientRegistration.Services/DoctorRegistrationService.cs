using Microsoft.EntityFrameworkCore;
using PatientRegistration.Core.Models;
using PatientRegistration.Core.Services;
using PatientRegistration.Database;

namespace PatientRegistration.Services
{
    public class DoctorRegistrationService: IEntityService<Doctor>
    {
        protected IRegistrationDbContext _context;

        public DoctorRegistrationService(IRegistrationDbContext context)
        {
            _context = context;
        }

        public Doctor GetById(int id) 
        {
            return _context.Set<Doctor>().Include(x=> x.Patients).SingleOrDefault(x => x.Id == id);
        }

        public List<Doctor> GetAll()
        {
            return _context.Set<Doctor>().Include(x=> x.Patients).ToList();
        }

        public void Add(Doctor doctor)
        { 
            _context.Set<Doctor>().Add(doctor);
            _context.SaveChanges();
        }

        public void Update(Doctor doctor)
        {
            _context.Entry(doctor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Doctor doctor)
        {
            var entityToDelete = _context.Set<Doctor>().SingleOrDefault(x => x.Id == doctor.Id);
            _context.Set<Doctor>().Remove(entityToDelete);
            _context.SaveChanges();
        }

        public void AddPatientToDoctor(int patientId, int doctorId)
        {
            var doctor = _context.Doctors.SingleOrDefault(x => x.Id == doctorId);
            var patient = _context.Patients.SingleOrDefault(x => x.Id == patientId);
            patient.DoctorId = doctor.Id;
            doctor.Patients.Add(patient);
            _context.SaveChanges();
        }
    }
}