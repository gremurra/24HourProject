using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class UserCreate
    {
        public object UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
