using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Repositories
{
    public interface IHealthRecordRepository
    {
        IEnumerable<HealthRecord> GetAllRecords();
        HealthRecord? GetRecordById(int id);
        int AddHealthRecord(HealthRecord record);
        int UpdateHealthRecord(HealthRecord record);
        int DeleteRecord(int id);
    }
}
