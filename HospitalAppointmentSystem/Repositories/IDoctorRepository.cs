using HospitalAppointmentSystem.Model;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Repositories
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctors> GetAllDoctors();
        Doctors? GetDoctorsById(int id);
        int AddDoctors(Doctors doctors);
        int UpdateDoctors(Doctors doctors);
        int DeleteDoctors(int id);
        DoctorInformation? GetInformationOfDoctors(int id);
        int UpdateDoctorsAndUser(Doctors doctors, Users users);
    }
}
