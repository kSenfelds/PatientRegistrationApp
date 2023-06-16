using Microsoft.EntityFrameworkCore;
using PatientRegistration.Core.Models;
using PatientRegistration.Core.Services;
using PatientRegistration.Database;

namespace PatientRegistration.Services
{
    public class PatientRegistrationService: IEntityService<Patient>
    {
        protected IRegistrationDbContext _context;

        public PatientRegistrationService(IRegistrationDbContext context)
        {
            _context = context;
        }
        public Patient GetById(int id)
        {
            return _context.Set<Patient>().SingleOrDefault(x => x.Id == id);
        }

        public List<Patient> GetAll()
        {
            return _context.Set<Patient>().ToList();
        }

        public void Add(Patient patient)
        {
            _context.Set<Patient>().Add(patient);
            _context.SaveChanges();
        }

        public void Update(Patient patient)
        {
            _context.Entry(patient).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Patient patient)
        {
            _context.Set<Patient>().Remove(patient);
            _context.SaveChanges();
        }

        public void AddPatientToDoctor(int patientId, int doctorId)
        {
            var patient = _context.Patients.SingleOrDefault(x => x.Id == patientId);
            if (patient.DoctorId != null)
            {
                var oldDoctor = _context.Doctors.SingleOrDefault(x => x.Id == patient.DoctorId);
                oldDoctor.Patients.Remove(patient);
            }
            var doctor = _context.Doctors.SingleOrDefault(x => x.Id == doctorId);
            patient.DoctorId = doctor.Id;
            doctor.Patients.Add(patient);
            _context.Doctors.Entry(doctor).State = EntityState.Modified;
            _context.SaveChanges();
        }   
    }
}
