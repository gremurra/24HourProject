using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class CommentDelete
    {
        [Required]
        public User Author { get; set; }
        [Required]
        public Post CommentPost { get; set; }
    }
}
