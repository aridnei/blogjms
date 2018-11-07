using JmBlog.Data.Contracts;
using JmBlog.Interfaces;
using JmBlog.Model;
using JmBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JmBlog.Services
{
    public class PostService : IPostService
    {
        private IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public void Create(PostCreateViewModel viewModel)
        {
            Post post = new Post();
            post.Title = viewModel.Title;
            post.Text = viewModel.Text;
            post.DatePublished = viewModel.DatePublished;
            post.UrlImage = viewModel.UrlImage;
            _postRepository.Save(post);
        }
    }
}
