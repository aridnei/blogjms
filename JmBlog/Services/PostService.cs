using JmBlog.Interfaces;
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
            Post post = new Post(viewModel.Title, viewModel.Text, viewModel.DatePublished, viewModel.UrlImage);
            _postRepository.Save();
        }
    }
}
