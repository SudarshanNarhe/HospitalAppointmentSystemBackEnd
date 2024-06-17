using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Services
{
    public interface IHealthRecordService
    {
        IEnumerable<HealthRecord> GetAllRecords();
        HealthRecord? GetRecordById(int id);
        int AddHealthRecord(HealthRecord record);
        int UpdateHealthRecord(HealthRecord record);
        int DeleteRecord(int id);
    }
}
