using System.ComponentModel.DataAnnotations;

namespace Presentation.Models.Requests
{
    public class AlbumRequest
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string? Description { get; set; } 
    }
}
