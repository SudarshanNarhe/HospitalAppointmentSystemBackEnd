using HospitalAppointmentSystem.Data;
using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Repositories
{
    public class SpecilityRepository : ISpecialtyRepository
    {
        private readonly ApplicationDbContext db;

        public SpecilityRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddSpeciality(Specialty specialty)
        {
            int result = 0;
            db.Specility.Add(specialty);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteSpeciality(int id)
        {
            int result = 0;
            var model = db.Specility.Where(user => user.SpecialtyID == id).FirstOrDefault();
            if (model != null)
            {
                db.Specility.Remove(model);
                result = db.SaveChanges();
                return result;
            }
            return result;
        }

        public IEnumerable<Specialty> GetSpecilities()
        {
            return db.Specility.ToList();
        }

        public Specialty? GetSpecilityById(int id)
        {
            return db.Specility.Where(use =>use.SpecialtyID==id).FirstOrDefault();
        }

        public int UpdateSpeciality(Specialty specialty)
        {
            int result = 0;
            var model = db.Specility.Where(user => user.SpecialtyID == specialty.SpecialtyID).FirstOrDefault();
            if (model != null)
            {
                model.SpecialtyName = specialty.SpecialtyName;
                result = db.SaveChanges();
                return result;
            }
            return result;
        }
    }
}
