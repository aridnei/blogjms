using JmBlog.Data.Contracts;
using JmBlog.Helpers;
using JmBlog.Interfaces;
using JmBlog.Model;
using JmBlog.ViewModels;
using System;

namespace JmBlog.Services
{
    public class PostService : IPostService
    {
        private IPostRepository _postRepository;
        const int numberOfWords = 5;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Post Create(PostCreateViewModel viewModel)
        {
            Post post = new Post();
            post.Title = viewModel.Title;
            post.Text = viewModel.Text;
            post.Summary = SummaryHelper.GetWords(viewModel.Text, numberOfWords);
            post.DatePublished = viewModel.DatePublished;
            post.DateUpdated = DateTime.Now;
            post.UrlImage = viewModel.UrlImage;
            _postRepository.Save(post);
            return post;
        }
    }
}
