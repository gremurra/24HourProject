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
    public class CommentService
    {
        private readonly Guid _userID;
        private int commentId;

        public int Id { get; private set; }
        public object Text { get; private set; }
        public object Author { get; private set; }
        public object CommentPost { get; private set; }
        public object ReplyComment { get; internal set; }

        public CommentService()
        {
        }



        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                Id = commentId,
                Text = model.Text,
                Author = model.Author,
                CommentPost = model.CommentPost,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Entry(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<Comment> GetCommnets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx.Comments.Select (
                       e =>
                            new Comment
                            {
                                Id = e.Id,
                                Author = e.Author,
                                Text = e.Text,
                                CommentPost= e.CommentPost,

                            });
                return query.ToList();
            }
        }
      
        
        public bool DeleteCommentService(int UserId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.Id == UserId); 




                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
