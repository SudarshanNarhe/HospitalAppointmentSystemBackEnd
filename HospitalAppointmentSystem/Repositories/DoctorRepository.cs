using HospitalAppointmentSystem.Data;
using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext db;

        public DoctorRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddDoctors(Doctors doctors)
        {
            int result = 0;
            db.Doctors.Add(doctors);
            result = db.SaveChanges();
            return result;

        }

        public int DeleteDoctors(int id)
        {
            int result = 0;
            var model = db.Doctors.Where(user => user.SpecialtyID == id).FirstOrDefault();
            if (model != null)
            {
                db.Doctors.Remove(model);
                result = db.SaveChanges();
                return result;
            }
            return result;
        }

        public IEnumerable<Doctors> GetAllDoctors()
        {
            return db.Doctors.ToList();
        }

        public Doctors? GetDoctorsById(int id)
        {
            return db.Doctors.Where(doc => doc.DoctorID == id).FirstOrDefault();
        }

        public int UpdateDoctors(Doctors doctors)
        {
            int result = 0;
            var model = db.Doctors.Where(user => user.SpecialtyID == doctors.DoctorID).FirstOrDefault();
            if (model != null)
            {
                model.UserID = doctors.UserID;
                model.SpecialtyID = doctors.SpecialtyID;
                result = db.SaveChanges();
                return result;
            }
            return result;
        }
    }
}
