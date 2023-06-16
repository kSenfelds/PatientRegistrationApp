namespace PatientRegistration.Core.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}