using System.Runtime.CompilerServices;

namespace Domain.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Count { get; set; }
        public int UserId { get; set; }
        
        public Album(int id,  string name, string description, int? count, int userId)
        {
            Id = id;
            Name = name;
            Description = description;
            Count = count;
            UserId = userId;
        }

        public Album() {
            Name = null!;
            Description = null!;
        }


        public override bool Equals(object? obj)
        {
            if (obj is not User other) return false;
            if (ReferenceEquals(this, other)) return true;

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}

