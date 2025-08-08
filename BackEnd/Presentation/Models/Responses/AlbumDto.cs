using System.ComponentModel.DataAnnotations;

namespace Presentation.Models.Responses
{
    public class AlbumDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string? Description { get; set; }

        public List<PostDto> Posts { get; set; } = new List<PostDto>();
    }
}
