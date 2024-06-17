using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Repositories;

namespace HospitalAppointmentSystem.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository repo;

        public StatusService(IStatusRepository repo)
        {
            this.repo = repo;
        }
        public int AddStatus(Status status)
        {
            return repo.AddStatus(status);
        }

        public int DeleteStatus(int id)
        {
            return repo.DeleteStatus(id);
        }

        public IEnumerable<Status> GetAllStatus()
        {
            return repo.GetAllStatus();
        }

        public Status? GetStatusById(int id)
        {
            return repo.GetStatusById(id);
        }

        public int UpdateStatus(Status status)
        {
            return repo.UpdateStatus(status);
        }
    }
}
