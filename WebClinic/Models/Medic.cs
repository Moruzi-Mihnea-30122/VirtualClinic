using System.ComponentModel.DataAnnotations;

namespace WebClinic.Models
{
    public class Medic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string FieldOfWork { get; set; }
    }
}
