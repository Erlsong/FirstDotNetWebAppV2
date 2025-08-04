using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string PenName { get; set; }
        public string HashedPassword { get; set; }
        public string Email { get; set; }

        public string Role {  get; set; }

        public Author(int id, string penName, string hashedPassword, string email, string role)
        {
            Id = id;
            PenName = penName;
            HashedPassword = hashedPassword;
            Email = email;
            Role = role;
        }

        public Author() {
            PenName = null!;
            HashedPassword = null!;
            Email = null!;
            Role = null!;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
