using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAppointmentSystem.Model
{
    [Table("Patients")]
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        public int UserID { get; set; }
      
    }
}
