using System.ComponentModel;

namespace Domain.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description {get; set;}
        public string Content { get; set;}
        public int AlbumId { get; set; }
        public int UserId { get; set; }

        public Post(int id, string title, string description, string content, int albumId, int userId)
        {
            Id = id;
            Title = title;
            Description = description;
            Content = content;
            AlbumId = albumId;
            UserId = userId;
        }
        public Post()
        {
            Title = null!;
            Description = null!;
            Content = null!;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
