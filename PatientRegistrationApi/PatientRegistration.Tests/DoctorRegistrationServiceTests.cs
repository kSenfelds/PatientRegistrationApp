using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PatientRegistration.Core.Models;
using PatientRegistration.Database;
using PatientRegistration.Services;

namespace PatientRegistration.Tests
{
    public class DoctorRegistrationServiceTests
    {
        private RegistrationDbContext _context;
        private DoctorRegistrationService _service;

        [SetUp]
        public void Setup()
        {
            SetupDatabase();
            _service = new DoctorRegistrationService(_context);
        }

        [Test]
        public void GetById_ValidId_ReturnsDoctor()
        {
            var doctor = _service.GetById(1);
            doctor.Should().NotBeNull();
            doctor.Name.Should().Be("James");
            doctor.LastName.Should().Be("Bond");
            doctor.PhoneNumber.Should().Be("123456789");
            doctor.Specialization.Should().Be("pediatrician");
            doctor.Patients.Should().BeNullOrEmpty();
        }

        [Test]
        public void GetAll_ReturnsListOfDoctors()
        {
            _service.GetAll().Count.Should().Be(1);
        }

        [Test]
        public void Add_ValidInfo_AddsDoctor()
        {
            Doctor newDoctor = new Doctor
            {
                Name = "John",
                LastName = "Smith",
                PhoneNumber = "987654321",
                Specialization = "dentist"
            };
            _service.Add(newDoctor);
            _service.GetAll().Count.Should().Be(2);
            _service.GetById(2).Name.Should().Be("John");

        }

        [Test]
        public void Update_ValidInfo_UpdatesDoctor()
        {
            var doctor = _service.GetById(1);
            var patient = new Patient
            {
                Name = "John",
                LastName = "Smith",
                Address = "Latvia",
                PhoneNumber = "11111111"
            };
            doctor.Patients = new List<Patient>();
            doctor.Patients.Add(patient);
            _service.Update(doctor);

            var updateDoctor = _service.GetById(1);
            updateDoctor.Patients.Count.Should().Be(1);
        }

        [Test]
        public void Delete_DeletesDoctor()
        {
            var doctor = _service.GetById(1);
            _service.Delete(doctor);

            _service.GetAll().Count.Should().Be(0);
        }

        private void SetupDatabase()
        {
            var options = new DbContextOptionsBuilder<RegistrationDbContext>().UseInMemoryDatabase("TestDB").Options;
            _context = new RegistrationDbContext(options);

            SeedDb();
        }
        public void SeedDb()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _context.Doctors.Add(new Doctor
            {
                Id = 1,
                Name = "James",
                LastName = "Bond",
                PhoneNumber = "123456789",
                Specialization = "pediatrician"

            });
            
            _context.SaveChanges();
            _context.Doctors.Count().Should().Be(1);
        }
    }
}