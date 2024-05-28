using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentSystem.Model
{
    [Table("userrole")]
    public class UserRole
    {
        [Key]
        public int Userrole_Id { get; set; }
        [Required]
        public string? Userrole { get; set; }
    }
}
