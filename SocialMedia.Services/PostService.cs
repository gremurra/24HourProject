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
        private int postId;



        public bool PostCreate(PostCreate model)
        {
            var entity = new Post()
            {
                Id = postId,
                Title = model.Title,
                Text = model.Text,
                Author = model.Author,

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Entry(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<Post> PostGet()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Where(e => e.Id == postId)
                    .Select(e =>
                                new Post
                                {
                                    Id = e.Id,
                                    Title = e.Title,
                                    Text = e.Text,
                                    Author = e.Author,

                                });
                return query.ToList();
            }
        }

        public Post GetPostbyID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Posts
                    .Single(e => e.Id == id && e.Id == postId);
                return
                    new Post
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Text = entity.Text,
                        Author = entity.Author,

                    };
            }
        }
        public bool PostUpdate(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.Id == model.Id);

                entity.Id = model.Id;
                entity.Title = model.Title;
                entity.Text = model.Text;
                entity.Author = model.Author;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool PostDelete(PostDelete post)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single
                    (e => e.Id == post.Id && e.Id == postId);
                ctx.Posts.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
