using System.ComponentModel.DataAnnotations;

namespace Application.Models.Responses
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

        public int UserId { get; set; }

        public List<PostDto> Posts { get; set; } = new List<PostDto>();
    }
}
