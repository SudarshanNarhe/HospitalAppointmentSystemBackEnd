using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Repositories;

namespace HospitalAppointmentSystem.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository repo;

        public AppointmentService(IAppointmentRepository repo)
        {
            this.repo = repo;
        }
        public int AddAppointment(Appointment appointment)
        {
            return repo.AddAppointment(appointment);
        }

        public int DeleteAppointment(int id)
        {
            return repo.DeleteAppointment(id);
        }

        public IEnumerable<Appointment> GetAllAppointment()
        {
            return repo.GetAllAppointment();
        }

        public Appointment? GetAppointmentById(int id)
        {
            return repo.GetAppointmentById(id);
        }

        public int UpdateAppointment(Appointment appointment)
        {
            return repo.UpdateAppointment(appointment);
        }
    }
}
