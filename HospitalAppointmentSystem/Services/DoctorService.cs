using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Repositories;

namespace HospitalAppointmentSystem.Services
{
    public class DoctorService : IDoctorsService
    {
        private readonly IDoctorRepository repo;

        public DoctorService(IDoctorRepository repo)
        {
            this.repo = repo;
        }
        public int AddDoctors(Doctors doctors)
        {
            return repo.AddDoctors(doctors);
        }

        public int DeleteDoctors(int id)
        {
            return repo.DeleteDoctors(id);
        }

        public IEnumerable<Doctors> GetAllDoctors()
        {
           return repo.GetAllDoctors();
        }

        public Doctors? GetDoctorsById(int id)
        {
            return repo.GetDoctorsById(id);
        }

        public int UpdateDoctors(Doctors doctors)
        {
            return repo.UpdateDoctors(doctors);
        }
    }
}
