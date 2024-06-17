using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAppointmentSystem.Model
{
    [Table("HealthRecords")]
    public class HealthRecord
    {
        [Key]
        public int RecordID { get; set; }
        public int PatientID { get; set; }
        public DateTime RecordDate { get; set; }
        public string? Details { get; set; }

    }
}
