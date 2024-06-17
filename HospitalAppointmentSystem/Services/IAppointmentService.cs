using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Services
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAllAppointment();
        Appointment? GetAppointmentById(int id);
        int AddAppointment(Appointment appointment);
        int UpdateAppointment(Appointment appointment);
        int DeleteAppointment(int id);
    }
}
