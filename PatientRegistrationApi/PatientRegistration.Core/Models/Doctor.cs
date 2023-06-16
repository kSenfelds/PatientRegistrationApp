namespace PatientRegistration.Core.Models
{
    public class Doctor : Entity
    {
        public Doctor()
        {
            Patients = new List<Patient>();
        }
        public string Specialization { get; set; }
        public string PhoneNumber { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
