using SocialMedia.Data;
using SocialMedia.Models;
using SocialMediaProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class UserService
    {
       
        private readonly Guid _userId;
        
        public string Name { get; private set; }
        public string Email { get; private set; }

       

        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    Name = model.Name,
                    Email = model.Email
                    
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<User> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx.Users.Select(
                       e =>
                            new User
                            {
                                Name = e.Name,
                                Email = e.Email,
                               
                            });
                return query.ToArray();
            }
        }
        public User GetUserByID(int UserId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .Single(e => e.Id == _userId);
                return
                    new User
                    {
                        UserId = entity.UserId,
                        Name = entity.Name,
                        Email = entity.Email,
                    };
            }
        }
      
       
    }
}
