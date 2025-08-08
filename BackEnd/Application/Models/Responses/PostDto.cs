namespace Application.Models.Responses
{
    public class PostDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Content { get; set; }

    public int UserId { get; set; }
    public int AlbumId { get; set; }
    public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
}
}
