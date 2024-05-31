using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Repositories
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctors> GetAllDoctors();
        Doctors? GetDoctorsById(int id);
        int AddDoctors(Doctors doctors);
        int UpdateDoctors(Doctors doctors);
        int DeleteDoctors(int id);
    }
}
