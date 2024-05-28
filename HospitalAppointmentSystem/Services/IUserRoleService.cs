using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Services
{
    public interface IUserRoleService
    {
        IEnumerable<UserRole> GetAllUserRole();
        UserRole GetUserRoleById(int id);
        int AddUserRole(UserRole userRole);
        int UpdateUserRole(UserRole userRole);
        int DeleteUserRole(int id);
    }
}
