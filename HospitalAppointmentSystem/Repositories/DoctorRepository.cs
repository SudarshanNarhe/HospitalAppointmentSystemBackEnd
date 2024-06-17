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
            var model = db.Doctors.Where(user => user.DoctorID == id).FirstOrDefault();
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

        public DoctorInformation? GetInformationOfDoctors(int id)
        {
            var query = from doctor in db.Doctors
                        join user in db.Users on doctor.UserID equals user.UserId
                        join speciality in db.Specility on doctor.SpecialtyID equals speciality.SpecialtyID
                        where doctor.DoctorID == id
                        select new DoctorInformation
                        {
                            DoctorId = doctor.DoctorID,
                            DoctorName = user.FirstName + " " + user.LastName,
                            DoctorEmail = user.Email,
                            Contact = user.Contact,
                            SpecialtyName = speciality.SpecialtyName
                        };
            return query.FirstOrDefault();
        }

        public int UpdateDoctors(Doctors doctors)
        {
            int result = 0;
            var model = db.Doctors.Where(user => user.DoctorID == doctors.DoctorID).FirstOrDefault();
            if (model != null)
            {
                model.UserID = doctors.UserID;
                model.SpecialtyID = doctors.SpecialtyID;
                result = db.SaveChanges();
                return result;
            }
            return result;
        }

        public int UpdateDoctorsAndUser(Doctors doctors, Users users)
        {
            int result = 0;
            var doctor = db.Doctors.Where(doctor => doctor.DoctorID == doctors.DoctorID).FirstOrDefault();
            var user = db.Users.Where(user => user.UserId == doctors.UserID).FirstOrDefault();
            if(doctor!= null && user != null) 
            {
                //to update a user
                user.FirstName = users.FirstName;
                user.LastName = users.LastName;
                user.UserName = users.UserName;
                user.Userrole_id = users.Userrole_id;
                user.Email = users.Email;
                user.Password = users.Password;
                user.Contact = users.Contact;
                user.DateOfBirth = users.DateOfBirth;
                user.Gender = users.Gender;
                //to update a doctor
                doctor.UserID = doctors.UserID;
                doctor.SpecialtyID = doctors.SpecialtyID;

                result = db.SaveChanges();
                return result;
            }
            return result;
        }
    }
}
