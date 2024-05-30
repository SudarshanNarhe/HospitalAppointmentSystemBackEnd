using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAppointmentSystem.Model
{
    [Table("Specialty")]
    public class Specialty
    {
        [Key]
        public int SpecialtyID { get; set; }
        [Required]
        public string? SpecialtyName { get; set;}
    }
}
