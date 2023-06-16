using Microsoft.EntityFrameworkCore;
using PatientRegistration.Core.Models;
using PatientRegistration.Core.Services;
using PatientRegistration.Database;

namespace PatientRegistration.Services
{
    public class DoctorRegistrationService: EntityService<Doctor>, IDoctorService
    {
        public DoctorRegistrationService(IRegistrationDbContext context): base(context)
        { }

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
            Update(doctor);
            _context.SaveChanges();
        }

        public Doctor GetDoctorWithPatients(int id)
        {
            return _context.Doctors.Include(x => x.Patients).SingleOrDefault(x => x.Id == id);
        }
    }
}