using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalAppointmentSystem.Model
{
    [Table("users")]
    public class Users
    {
        [Key]
        public int UserId { get; set; }
     
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
      
        public string? UserName { get; set; }
  
        public string? Email { get; set; }

        public string? Contact { get; set; }

        public string? Password { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string? Gender { get; set; }

        public int Userrole_id { get; set; }

    }
}
