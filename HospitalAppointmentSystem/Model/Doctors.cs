using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAppointmentSystem.Model
{
    [Table("Doctors")]
    public class Doctors
    {
        [Key]
        public int DoctorID { get; set; }
        public int UserID { get; set; }
        public int SpecialtyID { get; set; }
    }
}
