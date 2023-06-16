using Microsoft.AspNetCore.Mvc;
using PatientRegistration.Core.Models;
using PatientRegistration.Core.Services;


namespace PatientRegistrationApi.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IEntityService<Doctor> _doctorService;
        protected readonly IEntityService<Patient> _patientService;

        public BaseController(IEntityService<Doctor> doctorService,
            IEntityService<Patient> patientService)
        {
            _doctorService = doctorService;
            _patientService = patientService;
        }
    }
}
