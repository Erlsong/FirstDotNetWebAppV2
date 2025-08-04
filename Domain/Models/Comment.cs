using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int PostId { get; set; }

        public Comment(int id, string text, int postId)
        {
            Id = id;
            Text = text;
            PostId = postId;
        }
        public Comment() {
            Text = null!;
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
