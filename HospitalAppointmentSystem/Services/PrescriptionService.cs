using HospitalAppointmentSystem.Model;
using HospitalAppointmentSystem.Repositories;

namespace HospitalAppointmentSystem.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionsRepository repo;

        public PrescriptionService(IPrescriptionsRepository repo)
        {
            this.repo = repo;
        }
        public int AddPrescription(Prescriptions prescriptions)
        {
           return repo.AddPrescription(prescriptions);
        }

        public int DeletePrescription(int id)
        {
           return repo.DeletePrescription(id);
        }

        public IEnumerable<Prescriptions> GetAllPrecriptions()
        {
            return repo.GetAllPrecriptions();
        }

        public Prescriptions? GetPrescriptionById(int id)
        {
            return repo.GetPrescriptionById(id);
        }

        public int UpdatePrescription(Prescriptions prescriptions)
        {
            return repo.UpdatePrescription(prescriptions);
        }
    }
}
