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

        public CommentService()
        {
        }

        public CommentService(Guid userID)
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
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.PostService.add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItem> GetCommnets()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx.Comment.Select(
                       e =>
                            new UserListItem
                            {
                                Id = e.Id,
                                Text = e.Text,
                                Author = e.Author,
                                CommentPost = e.CommentPost,

                            });
                return query.ToList();
            }
        }
        public CommentServiceDetail GetCommentServiceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PostService
                        .Single(e => e.Id == id);

                var some = entity.ShopVariable.ShopServices;
                return
                    new CommentServiceDetail
                    {

                        Id = entity.Id,
                        Text = entity.Text,
                        Author = entity.Author,
                        CommentPost = entity.CommentPost,

                    };
            }
        }
        public bool UpdateComment(CommentServiceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PostService
                        .Single(e => e.Id == model.Id);

                entity.Id = model.Id;
                entity.Text = model.Text;
                entity.Author = model.Author;
                entity.CommentPost = model.CommentPost;


                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCommentService(int UserId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CommentServices
                        .Single(e => e.Id == UserId); //added in model.shopID




                ctx.PostService.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
