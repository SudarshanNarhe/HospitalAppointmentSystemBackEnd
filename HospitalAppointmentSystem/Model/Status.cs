using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAppointmentSystem.Model
{
    [Table("_status")]
    public class Status
    {
        [Key]
        public int statusId { get; set; }
        public string? _status { get; set; }
    }
}
