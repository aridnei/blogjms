using JmBlog.Data.Contracts;
using JmBlog.Helpers;
using JmBlog.Interfaces;
using JmBlog.Model;
using JmBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JmBlog.Services
{
    public class PostService : IPostService
    {
        private IPostRepository _postRepository;
        const int numberOfWords = 25;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<int> Create(PostCreateViewModel viewModel)
        {
            StringBuilder permalinkBuilder = new StringBuilder();

            Post post = new Post();
            permalinkBuilder.Append(PermalinkHelper.GenerateSlug(viewModel.Title));

            int countPermalinks = _postRepository.GetPermalinks(permalinkBuilder.ToString());
            if (countPermalinks > 0)
                permalinkBuilder.Append($"-{countPermalinks}");

            post.Permalink = permalinkBuilder.ToString();
            post.Title = viewModel.Title;
            post.Text = viewModel.Text;
            post.Summary = SummaryHelper.GetWords(viewModel.Text, numberOfWords);
            post.DatePublished = viewModel.DatePublished;
            post.DateUpdated = DateTime.Now;
            post.UrlImage = viewModel.UrlImage;
            await _postRepository.Save(post);
            return post.Id;
        }

        public Post GetByPermalink(string permalink)
        {
            return _postRepository.GetByPermalink(permalink);
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
