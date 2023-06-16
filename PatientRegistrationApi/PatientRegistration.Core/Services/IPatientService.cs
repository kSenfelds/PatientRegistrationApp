
using PatientRegistration.Core.Models;

namespace PatientRegistration.Core.Services
{
    public interface IPatientService: IEntityService<Patient>
    {
        Patient GetById(int id);
        List<Patient> GetAll();
        void Add(Patient patient);
        void Update(Patient patient);
        void Delete(Patient patient);
    }
}
