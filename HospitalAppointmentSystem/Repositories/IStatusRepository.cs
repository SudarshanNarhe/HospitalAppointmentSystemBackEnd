
using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Repositories
{
    public interface IStatusRepository
    {
        IEnumerable<Status> GetAllStatus();
        Status? GetStatusById(int id);
        int AddStatus(Status status);
        int UpdateStatus(Status status);
        int DeleteStatus(int id);
    }
}
