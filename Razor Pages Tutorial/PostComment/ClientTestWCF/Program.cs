using PostComment;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTestWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            PostCommentClient client = new PostCommentClient();

            var post = client.GetPostById(2);

            Console.WriteLine(post.PostId);
        }
    }
}
