using Microsoft.EntityFrameworkCore;
using PatientRegistration.Core.Models;
using PatientRegistration.Core.Services;
using PatientRegistration.Database;

namespace PatientRegistration.Services
{
    public class PatientRegistrationService: EntityService<Patient>, IPatientService
    {
        public PatientRegistrationService(IRegistrationDbContext context): base(context)
        { }
        
    }
}
