using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Repositories
{
    public interface IUserRoleRepository
    {
        IEnumerable<UserRole > GetAllUserRole();
        UserRole GetUserRoleById(int id);
        int AddUserRole(UserRole userRole);
        int UpdateUserRole(UserRole userRole);
        int DeleteUserRole(int id);
    }
}
