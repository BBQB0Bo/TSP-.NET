using API;
using PostComment;
using System;
using System.Collections.Generic;

namespace ObjectWCF
{
    public class PostComment : IPostComment
    {
        bool InterfaceComment.AddComment(Comment c)
        {
            APIComment service = new APIComment();
            return service.AddComment(c);
            
        }
        bool InterfacePost.AddPost()
        {
            APIPost service = new APIPost();
            return service.AddPost();
        }

        int InterfacePost.DeletePost(int id)
        {
            APIPost service = new APIPost();
            return service.DeletePost(id);
        }

        Comment InterfaceComment.GetCommentById(int id)
        {
            APIComment service = new APIComment();
            return service.GetCommentById(id);
        }

        Post InterfacePost.GetPostById(int id)
        {
            // E nevoie de ac instanta. Metodele din API sunt metode ale instantei.
            Post post = new Post();
            // Mesaj ce apare in server CUI. Nu e necesar.
            Console.WriteLine("GetPostById. Id = {0}", id);
            APIPost service = new APIPost();
            post = service.GetPostById(id); // Neclar acest cod.
            Console.WriteLine("Post returnat. Id = {0} , Description = {1}",
           post.PostId, post.Description);
            return post;
        }

        List<Post> InterfacePost.GetPosts()
        {
            APIPost service = new APIPost();
            return service.GetAllPosts();
        }

        Comment InterfaceComment.UpdateComment(Comment newComment)
        {
            APIComment service= new APIComment();
            return service.UpdateComment(newComment);
        }

        Post InterfacePost.UpdatePost(Post post)
        {
            APIPost service = new APIPost();
            return service.UpdatePost(post);
        }
    }
}
