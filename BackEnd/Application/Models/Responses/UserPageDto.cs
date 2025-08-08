namespace Application.Models.Responses
{
    public class UserPageDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public List<AlbumDto> Albums { get; set; } = new List<AlbumDto>();
        public List<PostDto> Posts { get; set; } = new List<PostDto> ();
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}
