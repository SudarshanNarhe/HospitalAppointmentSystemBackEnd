using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Repositories
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAllAppointment();
        Appointment? GetAppointmentById(int id);
        int AddAppointment(Appointment appointment);
        int UpdateAppointment(Appointment appointment);
        int DeleteAppointment(int id);
    }
}
