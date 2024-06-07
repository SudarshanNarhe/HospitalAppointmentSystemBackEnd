using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Repositories
{
    public interface IPatientsRepository
    {
        IEnumerable<Patient> GetAllPatients();
        Patient? GetPatientById(int id);
        int AddPatient(Patient patient);
        int UpdatePatient(Patient patient);
        int DeletePatient(int id);
    }
}
