
using Microsoft.EntityFrameworkCore;
using PatientRegistration.Core.Models;
using PatientRegistration.Core.Services;
using PatientRegistration.Database;

namespace PatientRegistration.Services
{
    public class EntityService<T> : IEntityService<T> where T : Entity
    {
        protected IRegistrationDbContext _context;

        public EntityService(IRegistrationDbContext context)
        {
            _context=context;
        }
        public T GetById(int id)
        {
            return _context.Set<T>().SingleOrDefault(x=> x.Id == id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

    }
}
