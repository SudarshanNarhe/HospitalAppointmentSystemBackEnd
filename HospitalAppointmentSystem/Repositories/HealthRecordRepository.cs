using HospitalAppointmentSystem.Data;
using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Repositories
{
    public class HealthRecordRepository : IHealthRecordRepository
    {
        private readonly ApplicationDbContext db;
        public HealthRecordRepository(ApplicationDbContext db) 
        {
            this.db = db;
        }

        public int AddHealthRecord(HealthRecord record)
        {
            int result = 0;
            db.HealthRecords.Add(record);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteRecord(int id)
        {
            int result = 0;
            var model = db.HealthRecords.Where(result => result.RecordID == id).FirstOrDefault();
            if (model != null)
            {
                db.HealthRecords.Remove(model);
                result = db.SaveChanges();
                return result;
            }
            return result;
        }

        public IEnumerable<HealthRecord> GetAllRecords()
        {
            return db.HealthRecords.ToList();
        }

        public HealthRecord? GetRecordById(int id)
        {
            return db.HealthRecords.Where(record =>  record.RecordID == id).FirstOrDefault();
        }

        public int UpdateHealthRecord(HealthRecord record)
        {
            int result = 0;
            var model = db.HealthRecords.Where(result => result.RecordID == record.RecordID).FirstOrDefault();
            if (model != null)
            {
                model.PatientID = record.PatientID;
                model.RecordDate = record.RecordDate;
                model.Details = record.Details;
                result = db.SaveChanges();
                return result;
            }
            return result;
        }
    }
}
