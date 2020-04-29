using DataBaseLibrary;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPostComment
{
    public class ServiceComment
    {

        private Comment comment;

        public ServiceComment()
        {
            comment = new Comment();
        }

        public bool AddComment()
        {
            using (Model1Container ctx = new Model1Container())
            {
                bool bResult = false;
                if (this == null || comment.PostPostId == 0)
                    return bResult;
                if (comment.CommentId == 0)
                {
                    ctx.Entry<Comment>(comment).State = EntityState.Added;
                    Post p = ctx.Posts.Find(comment.PostPostId);
                    ctx.Entry<Post>(p).State = EntityState.Unchanged;
                    ctx.SaveChanges();
                    bResult = true;
                }
                return bResult;
            }
        }

        public Comment UpdateComment(Comment newComment)
        {
            using (Model1Container ctx = new Model1Container())
            {
                Comment oldComment = ctx.Comments.Find(newComment.CommentId);
                // Deoarece parametrul este un Comment ar trebui verificata fiecare
                // proprietate din newComment daca are valoare atribuita si
                // daca valoarea este diferita de cea din bd.
                // Acest lucru il fac numai la modificarea asocierii.
                if (newComment.Text != null)
                    oldComment.Text = newComment.Text;
                if ((oldComment.PostPostId != newComment.PostPostId)
               && (newComment.PostPostId != 0))
                {
                    oldComment.PostPostId = newComment.PostPostId;
                }
                ctx.SaveChanges();
                return oldComment;
            }
        }

        public Comment GetCommentById(int id)
        {
            using (Model1Container ctx = new Model1Container())
            {
                var items = from c in ctx.Comments where (c.CommentId == id) select c;
                return items.Include(p => p.Post).SingleOrDefault();
            }
        }
    }
}
