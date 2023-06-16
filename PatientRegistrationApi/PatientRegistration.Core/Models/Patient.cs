namespace PatientRegistration.Core.Models
{
    public class Patient : Entity
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public int? DoctorId { get; set; }
    }
}
