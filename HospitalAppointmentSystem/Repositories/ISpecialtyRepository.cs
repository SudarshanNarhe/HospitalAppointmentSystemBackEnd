
using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Repositories
{
    public interface ISpecialtyRepository
    {
        IEnumerable<Specialty> GetSpecilities();
        Specialty? GetSpecilityById(int id);
        int AddSpeciality(Specialty specialty);
        int UpdateSpeciality(Specialty specialty);
        int DeleteSpeciality(int id);
    }
}
