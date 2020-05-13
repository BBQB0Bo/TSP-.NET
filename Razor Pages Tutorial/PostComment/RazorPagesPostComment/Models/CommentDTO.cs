using ServiceReferencePostComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesPostComment.Models
{
    public class CommentDTO
    {

        public int CommentId { get; set; }

        public string Text { get; set; }

        public int PostPostId { get; set; }

        public Post Post { get; set; } = new Post();
    }
}
