using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class PostDelete
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public User Author { get; set; }
    }
}
