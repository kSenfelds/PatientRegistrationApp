
using PatientRegistration.Core.Models;

namespace PatientRegistration.Core.Services
{
    public interface IDoctorService: IEntityService<Doctor>
    {
        void AddPatientToDoctor(int patientId, int doctorId);

        Doctor GetDoctorWithPatients(int id);
    }
}
