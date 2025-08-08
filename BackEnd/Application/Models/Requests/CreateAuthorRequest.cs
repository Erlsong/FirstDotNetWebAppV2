using System.ComponentModel.DataAnnotations;

namespace Application.Models.Requests
{
    public class CreateUserRequest
    {
        [Required]
        [MaxLength(100)]
        public string? PenName { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Password { get; set; }


        [Required]
        [MaxLength(100)]
        public string? Email { get; set; }

    }
}

