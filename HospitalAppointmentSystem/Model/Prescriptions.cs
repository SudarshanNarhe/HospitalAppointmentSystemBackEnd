using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAppointmentSystem.Model
{
    [Table("Prescriptions")]
    public class Prescriptions
    {
        [Key]
        public int PrescriptionID { get; set; }
        public int AppointmentID { get; set; }
        public string? Medication { get; set; }
        public string? Dosage { get; set; }
    }
}
