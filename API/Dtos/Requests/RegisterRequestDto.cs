using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Requests
{
    public class RegisterRequestDto
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
