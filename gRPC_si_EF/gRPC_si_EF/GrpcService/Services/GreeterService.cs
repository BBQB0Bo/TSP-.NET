using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPostComment;
using DataBaseLibrary;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Google.Protobuf.WellKnownTypes;


namespace GrpcService
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply{
                Message = "Hello " + request.Name
            });
        }

        public override Task<AddPostReply> AddPost(AddPostRequest request, ServerCallContext context)
        {
            ServicePost post = new ServicePost();

            return Task.FromResult(new AddPostReply
            {
                Result  = post.AddPost()
            });
        }

        public override Task<PostModel> UpdatePost(PostModel request, ServerCallContext context)
        {
            ServicePost post = new ServicePost();
            Post newPost = new Post(request.PostId, request.Description, request.Domain, request.Date.ToDateTime());
            Post oldPost = new Post();

            oldPost = post.UpdatePost(newPost);

            PostModel output = new PostModel();

            output.PostId = oldPost.PostId;
            output.Description = oldPost.Description;
            output.Domain = oldPost.Domain;
            output.Date = Timestamp.FromDateTime(oldPost.Date??DateTime.Now);

            return Task.FromResult(output);
        }

        public override Task<PostModel> GetPostById(GetPostByIdRequest request, ServerCallContext context)
        {
            ServicePost post = new ServicePost();

            Post recivePost = post.GetPostById(request.PostId);

            PostModel output = new PostModel();

            output.PostId = recivePost.PostId;
            output.Description = recivePost.Description;
            output.Domain = recivePost.Domain;
            output.Date = Timestamp.FromDateTime(recivePost.Date ?? DateTime.Now);

            return Task.FromResult(output);
        }

        public override Task<DeletePostReply> DeletePost(DeletePostRequest request, ServerCallContext context)
        {
            ServicePost post = new ServicePost();

            return Task.FromResult(new DeletePostReply
            {
                Result = post.DeletePost(request.PostId)
            });
        }


    }
}
