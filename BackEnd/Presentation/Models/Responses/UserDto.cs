namespace Presentation.Models.Responses
{
    public class UserDetailPageDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public List<AlbumDto> Albums { get; set; } = new List<AlbumDto>();
    }
}
