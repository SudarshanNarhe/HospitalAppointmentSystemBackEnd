
using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Repositories;

namespace HospitalAppointmentSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repo;

        public UserService(IUserRepository repo)
        {
            this.repo = repo;
        }
        public int AddUser(Users user)
        {
            return repo.AddUser(user);
        }

        public int DeleteUser(int id)
        {
            return repo.DeleteUser(id);
        }

        public Users? GetUserById(int id)
        {
            return repo.GetUserById(id);
        }

        public Users? GetUserByName(string name)
        {
            return repo.GetUserByName(name);
        }

        public IEnumerable<Users> GetUsers()
        {
            return repo.GetUsers();
        }

        public Users LoginUser(Users user)
        {
            return repo.LoginUser(user);
        }

        public int UpdateUser(Users user)
        {
            return repo.UpdateUser(user);
        }
    }
}
