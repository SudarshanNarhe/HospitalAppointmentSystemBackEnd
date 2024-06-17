using HospitalAppointmentSystem.Data;
using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Repositories
{
    public class PrescriptionRepository : IPrescriptionsRepository
    {
        private readonly ApplicationDbContext db;
        public PrescriptionRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddPrescription(Prescriptions prescriptions)
        {
            int result = 0;
            db.Prescriptions.Add(prescriptions);
            result = db.SaveChanges();
            return result;
        }

        public int DeletePrescription(int id)
        {
            int result = 0;
            var model = db.Prescriptions.Where(res => res.PrescriptionID == id).FirstOrDefault();
            if (model != null)
            {
                db.Prescriptions.Remove(model);
                result = db.SaveChanges();
                return result;
            }
            return result;
        }

        public IEnumerable<Prescriptions> GetAllPrecriptions()
        {
            return db.Prescriptions.ToList();
        }

        public Prescriptions? GetPrescriptionById(int id)
        {
            return db.Prescriptions.Where(res => res.PrescriptionID == id).FirstOrDefault();
        }

        public int UpdatePrescription(Prescriptions prescriptions)
        {
            int result = 0;
            var model = db.Prescriptions.Where(res => res.PrescriptionID == prescriptions.PrescriptionID).FirstOrDefault();
            if (model != null)
            {
                model.AppointmentID = prescriptions.AppointmentID;
                model.Medication = prescriptions.Medication;
                model.Dosage = prescriptions.Dosage;
                result = db.SaveChanges();
                return result;
            }
            return result;
        }
    }
}
