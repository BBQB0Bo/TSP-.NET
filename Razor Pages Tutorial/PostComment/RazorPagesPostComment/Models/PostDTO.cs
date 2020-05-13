using System;
using System.Collections.Generic;

namespace RazorPagesPostComment.Models
{
    public class PostDTO
    {

        public int PostId { get; set; }

        public string Description { get; set; }

        public string Domain { get; set; }

        public Nullable<System.DateTime> Date { get; set; }

        public List<CommentDTO> Comments { get; set; } = new List<CommentDTO>();
    }
}
