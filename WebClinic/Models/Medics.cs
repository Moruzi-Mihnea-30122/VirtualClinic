using System.ComponentModel.DataAnnotations;

namespace WebClinic.Models
{
    public class Medics
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
