using JmBlog.Data.Contracts;
using JmBlog.Helpers;
using JmBlog.Interfaces;
using JmBlog.Model;
using JmBlog.ViewModels;
using System;
using System.Collections.Generic;

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

        public int Create(PostCreateViewModel viewModel)
        {
            Post post = new Post();
            post.Title = viewModel.Title;
            post.Text = viewModel.Text;
            post.Summary = SummaryHelper.GetWords(viewModel.Text, numberOfWords);
            post.DatePublished = viewModel.DatePublished;
            post.DateUpdated = DateTime.Now;
            post.UrlImage = viewModel.UrlImage;
            _postRepository.Save(post);
            return post.Id;
        }

        public Post GetById(int id)
        {
            return _postRepository.GetById(id);
        }

        public IEnumerable<PostListViewModel> Get(PagingFilter paging)
        {
            if (!string.IsNullOrEmpty(paging.Filter))
                return _postRepository.GetByFilter(paging);

            return _postRepository.Get(paging);
        }
    }
}
