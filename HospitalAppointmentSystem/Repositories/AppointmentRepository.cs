using HospitalAppointmentSystem.Data;
using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext db;

        public AppointmentRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddAppointment(Appointment appointment)
        {
            int result = 0;
            db.Appointments.Add(appointment);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteAppointment(int id)
        {
            int result = 0;
            var model = db.Appointments.Where(appointId => appointId.AppointmentID == id).FirstOrDefault();
            if (model != null)
            {
               db.Appointments.Remove(model);
                result = db.SaveChanges();
                return result;
            }
            return result;
        }

        public IEnumerable<Appointment> GetAllAppointment()
        {
            return db.Appointments.ToList();
        }

        public Appointment? GetAppointmentById(int id)
        {
            return db.Appointments.Where(appointId => appointId.AppointmentID==id).FirstOrDefault();
        }

        public int UpdateAppointment(Appointment appointment)
        {
            int result = 0;
            var model = db.Appointments.Where(appointId => appointId.AppointmentID == appointment.AppointmentID).FirstOrDefault();
            if (model != null)
            {
                model.PatientID = appointment.PatientID;
                model.DoctorID = appointment.DoctorID;
                model.AppointmentDate = appointment.AppointmentDate;
                model.Reason = appointment.Reason;
                model.StatusId = appointment.StatusId;
                model.Charges = appointment.Charges;
                result = db.SaveChanges();
                return result;
            }
            return result;
        }
    }
}
