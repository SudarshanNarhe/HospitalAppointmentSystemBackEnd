using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Services
{
    public interface ISpecilityService
    {
        IEnumerable<Specialty> GetSpecilities();
        Specialty? GetSpecilityById(int id);
        int AddSpeciality(Specialty specialty);
        int UpdateSpeciality(Specialty specialty);
        int DeleteSpeciality(int id);
    }
}
