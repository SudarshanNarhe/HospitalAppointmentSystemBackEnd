using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentSystem.Model
{
    [Table("users")]
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
      
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Contact { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public int Userrole_id { get; set; }

    }
}
