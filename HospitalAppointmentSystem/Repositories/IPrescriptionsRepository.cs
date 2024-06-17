using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Repositories
{
    public interface IPrescriptionsRepository
    {
        IEnumerable<Prescriptions> GetAllPrecriptions();
        Prescriptions? GetPrescriptionById(int id);
        int AddPrescription(Prescriptions prescriptions);
        int UpdatePrescription(Prescriptions prescriptions);
        int DeletePrescription(int id);
    }
}
