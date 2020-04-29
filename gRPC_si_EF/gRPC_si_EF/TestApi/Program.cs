using ApiPostComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePost post = new ServicePost();
            post.AddPost();

        }
    }
}
