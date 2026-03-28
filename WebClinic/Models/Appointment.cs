using System.ComponentModel.DataAnnotations;

namespace WebClinic.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int PacientId  { get; set; }
        public int MedicId { get; set; }
    }
}
