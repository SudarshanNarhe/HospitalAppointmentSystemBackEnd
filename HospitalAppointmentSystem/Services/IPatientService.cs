using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Services
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAllPatients();
        Patient? GetPatientById(int id);
        int AddPatient(Patient patient);
        int UpdatePatient(Patient patient);
        int DeletePatient(int id);
    }
}
