using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Services
{
    public interface IStatusService
    {
        IEnumerable<Status> GetAllStatus();
        Status? GetStatusById(int id);
        int AddStatus(Status status);
        int UpdateStatus(Status status);
        int DeleteStatus(int id);
    }
}
