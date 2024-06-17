using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Repositories;

namespace HospitalAppointmentSystem.Services
{
    public class HealthRecordService : IHealthRecordService
    {
        private readonly IHealthRecordRepository repo;

        public HealthRecordService(IHealthRecordRepository repo)
        {
            this.repo = repo;
        }
        public int AddHealthRecord(HealthRecord record)
        {
            return repo.AddHealthRecord(record);
        }

        public int DeleteRecord(int id)
        {
            return repo.DeleteRecord(id);
        }

        public IEnumerable<HealthRecord> GetAllRecords()
        {
            return repo.GetAllRecords();
        }

        public HealthRecord? GetRecordById(int id)
        {
            return repo.GetRecordById(id);
        }

        public int UpdateHealthRecord(HealthRecord record)
        {
            return repo.UpdateHealthRecord(record);
        }
    }
}
