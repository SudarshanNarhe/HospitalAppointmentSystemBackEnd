using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Services
{
    public interface IUserService
    {
        IEnumerable<Users> GetUsers();
        Users? GetUserById(int id);
        Users? GetUserByName(string name);
        int AddUser(Users user);
        int UpdateUser(Users user);
        int DeleteUser(int id);

        Users? LoginUser(Users user);
    }
}
