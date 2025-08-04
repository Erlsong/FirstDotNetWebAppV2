using System.Runtime.CompilerServices;

namespace Domain.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Count { get; set; }
        public int AuthorId { get; set; }
        
        public Album(int id,  string name, string description, int? count, int authorId)
        {
            Id = id;
            Name = name;
            Description = description;
            Count = count;
            AuthorId = authorId;
        }

        public Album() {
            Name = null!;
            Description = null!;
        }


        public override bool Equals(object? obj)
        {
            if (obj is not Author other) return false;
            if (ReferenceEquals(this, other)) return true;

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

