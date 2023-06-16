using PatientRegistration.Core.Models;

namespace PatientRegistration.Core.Services
{
    public interface IEntityService<T> where T : Entity
    {
        T GetById(int id);
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void AddPatientToDoctor(int patientId, int doctorId);
    }
}
