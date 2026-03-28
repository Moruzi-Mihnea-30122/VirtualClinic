using System.ComponentModel.DataAnnotations;

namespace WebClinic.Models;

public class Pacient
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    [MinLength(10)]
    public string TelNumber { get; set; }

    public string Role { get; set; }
}

