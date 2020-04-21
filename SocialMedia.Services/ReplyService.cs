using SocialMedia.Data;
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


        private readonly Guid _userID;

        public ReplyService()
        {
        }

        public ReplyService(Guid userID)
        {
            _userID = userID;
        }

        public Guid Id { get; private set; }
        public object Text { get; private set; }
        public object Author { get; private set; }
        public object CommentPost { get; private set; }

        public bool CreateComment(CommentServiceCreate model)
        {
            var entity = new CommentService()
            {
                Id = _userID,
                Text = model.Text,
                Author = model.Author,
                CommentPost = model.CommentPost,
                ReplyComment = model.ReplyComment,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.ReplyService.add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReplyListItem> GetReply()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx.Comment.Select(
                       e =>
                            new ReplyListItem
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
        public ReplyServiceDetail GetReplyServiceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ReplyService
                        .Single(e => e.UserId == id);

                var some = entity.ShopVariable.ShopServices;
                return
                    new ReplyServiceDetail
                    {

                        Id = entity.Id,
                        Text = entity.Text,
                        Author = entity.Author,
                        CommentPost = entity.CommentPost,
                        ReplyComment = entity.ReplyComment,

                    };
            }
        }
        public bool UpdateReply(ReplyServiceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ReplyService
                        .Single(e => e.UserId == model.Id);

                entity.Id = model.Id;
                entity.Text = model.Text;
                entity.Author = model.Author;
                entity.CommentPost = model.CommentPost;
                entity.ReplyComment = model.ReplyComment;


                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteReplyService(int UserId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ReplyServices
                        .Single(e => e.ReplyComment == UserId); 




                ctx.ReplyService.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
