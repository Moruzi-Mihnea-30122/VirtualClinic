using System.ComponentModel.DataAnnotations;

namespace WebClinic.Models
{
    public class Appointments
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime date { get; set; }

        public int pacientId  { get; set; }
        public int medicId { get; set; }
    }
}
