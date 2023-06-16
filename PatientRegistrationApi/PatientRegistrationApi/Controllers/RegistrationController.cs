using Microsoft.AspNetCore.Mvc;
using PatientRegistration.Core.Models;
using PatientRegistration.Core.Services;

namespace PatientRegistrationApi.Controllers
{
    [Route("api/Registration")]
    [ApiController]
    public class RegistrationController : BaseController
    {
        public RegistrationController(IDoctorService doctorService, IPatientService patientService) : base(doctorService, patientService)
        {
        }

        [HttpGet("GetAllDoctors")]
        public IActionResult GetAllDoctors()
        {
            var doctors = _doctorService.GetAll();
            return Ok(doctors);
        }

        [HttpGet("GetAllPatients")]
        public IActionResult GetAllPatients()
        {
            var patients = _patientService.GetAll();
            return Ok(patients);
        }

        [HttpGet("GetPatientByDoctor")]
        public IActionResult GetPatientByDoctor(int doctorId)
        {
            var doctor = _doctorService.GetDoctorWithPatients(doctorId);
            return Ok(doctor.Patients);
        }

        [HttpPost("AddDoctor")]
        public IActionResult AddDoctor(Doctor doctor)
        {
            _doctorService.Add(doctor);
            return Ok();
        }

        [HttpPost("AddPatient")]
        public IActionResult AddPatient(Patient patient)
        {
            _patientService.Add(patient);
            return Ok();
        }

        [HttpPost("AddPatientToDoctor")]
        public IActionResult AddPatientToDoctor(int patientId, int doctorId)
        {
            _doctorService.AddPatientToDoctor(patientId, doctorId);
            return Ok();
        }

        [HttpPut("UpdateDoctor")]
        public IActionResult UpdateDoctor(Doctor doctor)
        {
            _doctorService.Update(doctor);
            return Ok();
        }

        [HttpPut("UpdatePatient")]
        public IActionResult UpdatePatient(Patient patient)
        {
            _patientService.Update(patient);
            return Ok();
        }

        [HttpDelete("DeleteDoctor")]
        public IActionResult DeleteDoctor(int doctorId)
        {
            var doctor = _doctorService.GetById(doctorId);
            _doctorService.Delete(doctor);
            return Ok();
        }

        [HttpDelete("DeletePatient")]
        public IActionResult DeletePatient(int patientId)
        {
            var patient = _patientService.GetById(patientId);
            _patientService.Delete(patient);
            return Ok();
        }

        [HttpDelete("DeletePatientFromDoctor")]
        public IActionResult DeletePatientFromDoctor(int patientId, int doctorId)
        {
            var doctor = _doctorService.GetById(doctorId);
            var patient = _patientService.GetById(patientId);
            doctor.Patients.Remove(patient);
            _doctorService.Update(doctor);
            return Ok();
        }
        
    }
}