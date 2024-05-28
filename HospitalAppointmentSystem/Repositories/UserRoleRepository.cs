using HospitalAppointmentSystem.Data;
using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ApplicationDbContext db;

        public UserRoleRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddUserRole(UserRole userRole)
        {
            int result = 0;
            db.Roles.Add(userRole);
           result = db.SaveChanges();
            return result;
        }

        public int DeleteUserRole(int id)
        {
            int result = 0;
            var model = db.Roles.Where(role => role.Userrole_Id == id).FirstOrDefault();
            if(model != null)
            {
                db.Roles.Remove(model);
                result = db.SaveChanges();
                return result;
            }
            return result;
        }

        public IEnumerable<UserRole> GetAllUserRole()
        {
            return db.Roles.ToList();
        }

        public UserRole GetUserRoleById(int id)
        {
            return db.Roles.Where(roles => roles.Userrole_Id == id).FirstOrDefault();
        }

        public int UpdateUserRole(UserRole userRole)
        {
            int result = 0;
            var model = db.Roles.Where(role => role.Userrole_Id == userRole.Userrole_Id).FirstOrDefault();
            if (model != null)
            {
                model.Userrole = userRole.Userrole;
                result = db.SaveChanges();
                return result;
            }
            return result;
        }
    }
}
