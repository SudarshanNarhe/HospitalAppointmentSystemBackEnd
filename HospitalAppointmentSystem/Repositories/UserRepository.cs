
using HospitalAppointmentSystem.Data;
using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext db;

        public UserRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddUser(Users user)
        {
            int result = 0;
            db.Users.Add(user);
            result = db.SaveChanges();
            return result;
        }

        public int DeleteUser(int id)
        {
            int result = 0;
            var model = db.Users.Where(user=>user.UserId == id).FirstOrDefault();
            if(model != null)
            {
                db.Users.Remove(model);
               result =  db.SaveChanges();
                return result;
            }
           return result;
        }

        public Users? GetUserById(int id)
        {
            return db.Users.Where(user => user.UserId == id).FirstOrDefault();
        }

        public IEnumerable<Users> GetUsers()
        {
            return db.Users.ToList();
        }

        public Users? LoginUser(string username, string password)
        {
            var model = db.Users.Where(user => user.UserName== username && user.Password==password).FirstOrDefault();
            if (model != null)
            {
                return model;
            }
            else
                return null;
        }

        public int UpdateUser(Users user)
        {
            int result = 0;
            var model = db.Users.Where(user => user.UserId == user.UserId).FirstOrDefault();
            if (model != null)
            {
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.UserName = user.UserName;
                model.Userrole_id = user.Userrole_id;
                model.Email = user.Email; 
                model.Password = user.Password;
                model.Contact = user.Contact;
                result = db.SaveChanges();
                return result;
            }
            return result;
        }
    }
}
