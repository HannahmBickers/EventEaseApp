using System.ComponentModel.DataAnnotations;

namespace EventEaseApp.Models
{
    public class RegistrationModel
    {
        [Required]
        public string? Name { get; set; }

        [Required, EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? EventName { get; set; }
    }
}
