using EventStore.ClientAPI.UserManagement;
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
       
        private readonly object userId;

        public object UserId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

       

        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    UserId = model.UserId,
                    Name = model.Name,
                    Email = model.Email
                    
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.User.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx.User.Select(
                       e =>
                            new UserListItem
                            {
                                UserId = e.UserId,
                                Name = e.Name,
                                Email = e.Email,
                               
                            });
                return query.ToArray();
            }
        }
        public UserService GetUserByID(int UserId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Users
                    .Single(e => e.UserId == UserId);
                return
                    new UserServices
                    {
                        UserId = entity.UserId,
                        Name = entity.Name,
                        Email = entity.Email,
                    };
            }
        }
        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.User.Single
                    (e => e.UserId == model.UserId);
                entity.Name = model.Name;
                entity.Email = model.Email;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteUser(int UserId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .User
                    .Single(e => e.UserId == userId);
                ctx.User.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
