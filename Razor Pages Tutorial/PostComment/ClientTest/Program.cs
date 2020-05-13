using API;
using PostComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            APIPost service = new APIPost();
            List<Post> list = service.GetAllPosts();
            foreach (Post p in list)
            {
                foreach (Comment c in p.Comments)
                    Console.WriteLine(c.CommentId);
            }
        }
    }
}
