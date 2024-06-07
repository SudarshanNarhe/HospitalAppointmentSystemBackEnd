using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Repositories;

namespace HospitalAppointmentSystem.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientsRepository repo;

        public PatientService(IPatientsRepository repo)
        {
            this.repo = repo;
        }

        public int AddPatient(Patient patient)
        {
            return repo.AddPatient(patient);
        }

        public int DeletePatient(int id)
        {
            return repo.DeletePatient(id);
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return repo.GetAllPatients();
        }

        public Patient? GetPatientById(int id)
        {
            return repo.GetPatientById(id);
        }

        public int UpdatePatient(Patient patient)
        {
            return repo.UpdatePatient(patient);
        }
    }
}
