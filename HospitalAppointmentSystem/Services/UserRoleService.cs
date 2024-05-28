using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Repositories;

namespace HospitalAppointmentSystem.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository repo;

        public UserRoleService(IUserRoleRepository repo)
        {
            this.repo = repo;
        }
        public int AddUserRole(UserRole userRole)
        {
            return repo.AddUserRole(userRole);
        }

        public int DeleteUserRole(int id)
        {
            return repo.DeleteUserRole(id);
        }

        public IEnumerable<UserRole> GetAllUserRole()
        {
            return repo.GetAllUserRole();
        }

        public UserRole GetUserRoleById(int id)
        {
            return repo.GetUserRoleById(id);
        }

        public int UpdateUserRole(UserRole userRole)
        {
            return repo.UpdateUserRole(userRole);
        }
    }
}
