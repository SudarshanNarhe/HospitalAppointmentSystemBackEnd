using HospitalAppointmentSystem.Model;

namespace HospitalAppointmentSystem.Services
{
    public interface IPrescriptionService
    {
        IEnumerable<Prescriptions> GetAllPrecriptions();
        Prescriptions? GetPrescriptionById(int id);
        int AddPrescription(Prescriptions prescriptions);
        int UpdatePrescription(Prescriptions prescriptions);
        int DeletePrescription(int id);
    }
}
