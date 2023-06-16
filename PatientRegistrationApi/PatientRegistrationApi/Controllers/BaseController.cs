using Microsoft.AspNetCore.Mvc;
using PatientRegistration.Core.Models;
using PatientRegistration.Core.Services;


namespace PatientRegistrationApi.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IDoctorService _doctorService;
        protected readonly IPatientService _patientService;

        public BaseController(IDoctorService doctorService,
            IPatientService patientService)
        {
            _doctorService = doctorService;
            _patientService = patientService;
        }
    }
}
