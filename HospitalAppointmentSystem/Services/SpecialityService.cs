using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Repositories;

namespace HospitalAppointmentSystem.Services
{
    public class SpecialityService : ISpecilityService
    {
        private readonly ISpecialtyRepository repo;

        public SpecialityService(ISpecialtyRepository repo)
        {
            this.repo = repo;
        }
        public int AddSpeciality(Specialty specialty)
        {
            return repo.AddSpeciality(specialty);
        }

        public int DeleteSpeciality(int id)
        {
            return repo.DeleteSpeciality(id);
        }

        public IEnumerable<Specialty> GetSpecilities()
        {
            return repo.GetSpecilities();
        }

        public Specialty? GetSpecilityById(int id)
        {
            return repo.GetSpecilityById(id);
        }

        public int UpdateSpeciality(Specialty specialty)
        {
           return repo.UpdateSpeciality(specialty);
        }
    }
}
