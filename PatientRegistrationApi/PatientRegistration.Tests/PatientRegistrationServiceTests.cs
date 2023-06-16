using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PatientRegistration.Core.Models;
using PatientRegistration.Database;
using PatientRegistration.Services;

namespace PatientRegistration.Tests;

public class PatientRegistrationServiceTests
{
    private RegistrationDbContext _context;
    private PatientRegistrationService _service;
    
    [SetUp]
    public void Setup()
    {
        SetupDatabase();
        _service = new PatientRegistrationService(_context);
    }

    [Test]
    public void GetById_ValidInfo_ReturnsPatient()
    {
        var patient = _service.GetById(1);

        patient.Name.Should().Be("James");
        patient.LastName.Should().Be("Bond");
        patient.PhoneNumber.Should().Be("123456789");
        patient.Address.Should().Be("TestAddress");
    }

    [Test]
    public void GetAll_ReturnsListOfPatients()
    {
        _service.GetAll().Count.Should().Be(1);
    }

    [Test]
    public void Add_ValidInfo_AddsPatient()
    {
        var newPatient = new Patient
        {
            Name = "Kriss",
            LastName = "Kross",
            PhoneNumber = "1234567890",
            Address = "Latvia"
        };
        _service.Add(newPatient);
        _service.GetAll().Count.Should().Be(2);
    }

    [Test]
    public void Update_UpdatesPatient()
    {
        var patient = _service.GetById(1);
        patient.Name = "NewName";
        _service.Update(patient);

        _service.GetById(1).Name.Should().Be("NewName");
    }

    [Test]
    public void Delete_DeletesPatient()
    {
        var patient = _service.GetById(1);
        _service.Delete(patient);
        _service.GetAll().Count.Should().Be(0);
    }

    [Test]
    public void AddPatientToDoctor_ValidInfo_AddsPatientToDoctorsPatientList()
    {
        _service.AddPatientToDoctor(1, 1);
        var doctor = _context.Doctors.FirstOrDefault(x => x.Id == 1);
        doctor.Patients.Count.Should().Be(1);
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

        _context.Patients.Add(new Patient
        {
            Id = 1,
            Name = "James",
            LastName = "Bond",
            PhoneNumber = "123456789",
            Address = "TestAddress"

        });
        _context.Doctors.Add(new Doctor
        {
            Id = 1,
            PhoneNumber = "123456789",
            Name = "Doctor",
            LastName = "Smith",
            Specialization = "Dentist"
        });

        _context.SaveChanges();
        _context.Patients.Count().Should().Be(1);
    }
}