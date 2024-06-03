using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Requests
{
    public class ForgotPasswordRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
