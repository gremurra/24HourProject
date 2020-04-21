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
    public class PostService
    {
        private readonly Guid _userID;

        public PostService()
        {
        }

        public PostService(Guid userID)
        {
            _userID = userID;
        }

        public Guid Id { get; private set; }
        public object Titlte { get; private set; }
        public object Text { get; private set; }
        public object Author { get; private set; }

        public bool PostCreate(PostCreate model)
        {
            var entity = new PostService()
            {
                Id = _userID,
                Titlte = model.Titlte,
                Text = model.Text,
                Author = model.Author,
               
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.PostService.add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PostListItem> PostGet()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Where(e => e.UserID == _userID)
                    .Select(e =>
                                new PostListItem
                                {
                                    Id = e.Id,
                                    Title = e.Title,
                                    Text = e.Text,
                                    Author = e.Author,
                                  
                                });
                return query.ToList();
            }
        }

        public PostDetail GetPostbyID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Include(e => e.Text)
                    .Single(e => e.Id == id && e.UserId == _userID);
                return
                    new PostDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Text = entity.Text,
                        Author = entity.Author,
                        
                    };
            }
        }
        public bool PostUpdate(PostServiceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PostService
                        .Single(e => e.Id == model.Equals);

                entity.Id = model.Id;
                entity.Title = model.Title;
                entity.Text = model.Text;
                entity.Author = model.Author;
               

                return ctx.SaveChanges() == 1;
            }
        }

        public bool PostDelete(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single
                    (e => e.Id == Id && e.UserID == _userID);
                ctx.Posts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
