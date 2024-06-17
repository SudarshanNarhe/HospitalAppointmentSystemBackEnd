using HospitalAppointmentSystem.Data;
using HospitalAppointmentSystem.Repositories;
using HospitalAppointmentSystem.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//configuration for database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add CORS services for angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDevServer",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200") // Allow requests from Angular dev server
                 .AllowAnyHeader()
                 .AllowAnyMethod()
                 .AllowCredentials();
        });
});

//configuraton for session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//for userrole 
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
//for user
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
//for specility
builder.Services.AddScoped<ISpecialtyRepository, SpecilityRepository>();
builder.Services.AddScoped<ISpecilityService, SpecialityService>();
//for doctors
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorsService, DoctorService>();
//for patients
builder.Services.AddScoped<IPatientsRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
//for status
builder.Services.AddScoped<IStatusRepository , StatusRepository>();
builder.Services.AddScoped<IStatusService, StatusService>();
//for Appointment
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
//for HealthRecord
builder.Services.AddScoped<IHealthRecordRepository, HealthRecordRepository>();
builder.Services.AddScoped<IHealthRecordService, HealthRecordService>();
//for Prescriptions
builder.Services.AddScoped<IPrescriptionsRepository, PrescriptionRepository>();
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();



// Add distributed memory cache
builder.Services.AddDistributedMemoryCache(); // This line is essential

var app = builder.Build();

//for use session
app.UseSession();

//for use a angular
app.UseCors("AllowAngularDevServer");

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
