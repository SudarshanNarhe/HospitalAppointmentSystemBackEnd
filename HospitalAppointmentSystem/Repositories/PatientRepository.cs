using HospitalAppointmentSystem.Data;
using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Repositories
{
    public class PatientRepository : IPatientsRepository
    {
        private readonly ApplicationDbContext db;

        public PatientRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddPatient(Patient patient)
        {
            int result = 0;
            db.Patients.Add(patient);
            result = db.SaveChanges();
            return result;

        }

        public int DeletePatient(int id)
        {
            int result = 0;
            var model = db.Patients.Where(user => user.UserID == id).FirstOrDefault();
            if (model != null)
            {
                db.Patients.Remove(model);
                result = db.SaveChanges();
                return result;
            }
            return result;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return db.Patients.ToList();
        }

        public Patient? GetPatientById(int id)
        {
            return db.Patients.Where(pat =>pat.UserID== id).FirstOrDefault();
        }

        public int UpdatePatient(Patient patient)
        {
            int result = 0;
            var model = db.Patients.Where(user => user.PatientID == patient.PatientID).FirstOrDefault();
            if (model != null)
            {
                model.UserID = patient.UserID;
                result = db.SaveChanges();
                return result;
            }
            return result;
        }
    }
}
