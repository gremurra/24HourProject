using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public User Author { get; set; }
        public Post CommentPost { get; set; }

        public static implicit operator Comment(Guid v)
        {
            throw new NotImplementedException();
        }
    }
}
