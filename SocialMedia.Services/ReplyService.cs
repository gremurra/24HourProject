using SocialMedia.Data;
using SocialMedia.Models;
using SocialMediaProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class ReplyService
    {
        private int replyId;

        public bool CreateReply(ReplyCreate model)
        {
            var entity = new Reply()
            {
                Id = replyId,
                Text = model.Text,
                Author = model.Author,
                CommentPost = model.CommentPost,
                ReplyComment = model.ReplyComment,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Entry(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<Reply> GetReply()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx.Replies.Select(
                       e =>
                            new Reply
                            {
                                Id = e.Id,
                                Text = e.Text,
                                Author = e.Author,
                                CommentPost = e.CommentPost,
                                ReplyComment = e.ReplyComment,

                            });
                return query.ToList();
            }
        }


    }
}
