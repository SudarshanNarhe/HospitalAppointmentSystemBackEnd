using HospitalAppointmentSystem.Data;
using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ApplicationDbContext db;

        public StatusRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddStatus(Status status)
        {
            int result = 0;
            db.Status.Add(status);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteStatus(int id)
        {
            int result = 0;
            var model = db.Status.Where(status=> status.statusId==id).FirstOrDefault();
            if (model != null)
            {
                db.Status.Remove(model); 
                result = db.SaveChanges();
                return result;
            }
            return result;
        }

        public IEnumerable<Status> GetAllStatus()
        {
            return db.Status.ToList();
        }

        public Status? GetStatusById(int id)
        {
            return db.Status.Where(status=> status.statusId== id).FirstOrDefault();
        }

        public int UpdateStatus(Status status)
        {
            int result = 0;
            var model = db.Status.Where(res => res.statusId == status.statusId).FirstOrDefault();
            if (model != null)
            {
                model._status = status._status;
                result = db.SaveChanges();
                return result;
            }
            return result;
        }
    }
}
