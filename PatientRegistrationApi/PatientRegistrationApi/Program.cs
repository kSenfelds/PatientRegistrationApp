using Microsoft.EntityFrameworkCore;
using PatientRegistration.Core.Models;
using PatientRegistration.Core.Services;
using PatientRegistration.Database;
using PatientRegistration.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddDbContext<RegistrationDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("RegistrationDbContext")));

builder.Services.AddScoped<IRegistrationDbContext, RegistrationDbContext>();
builder.Services.AddScoped<IEntityService<Patient>, PatientRegistrationService>();
builder.Services.AddScoped<IEntityService<Doctor>, DoctorRegistrationService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options => options.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();