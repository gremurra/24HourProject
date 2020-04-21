
using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class PostCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(8000)]
        public string Text { get; set; }
        [Required]
        public User Author { get; set; }
    }
}
