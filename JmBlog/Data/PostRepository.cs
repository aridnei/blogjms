using System.Threading.Tasks;
using System.Linq;
using JmBlog.Model;
using JmBlog.Data.Contracts;
using System.Collections;
using JmBlog.ViewModels;
using System.Collections.Generic;

namespace JmBlog.Data
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogContext _context;
        private const int page = 0;
        private const int size = 10;

        public PostRepository(BlogContext context)
        {
            this._context = context;
        }

        public async Task Save(Post post)
        {
            await _context.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public Post GetById(int postId)
        {
            return _context.Posts.FirstOrDefault(p => p.Id == postId);
        }

        public Post GetByPermalink(string permalink)
        {
            return _context.Posts.FirstOrDefault(x => x.Permalink.Equals(permalink));
        }

        public int GetPermalinks(string permalink)
        {
            return _context.Posts.Where(x => x.Permalink.Equals(permalink)).Count();
        }

        public IEnumerable<PostListViewModel> Get(PagingFilter paging)
        {
            var query = _context.Posts.Where(x => x.DatePublished != null)
                .OrderByDescending(x => x.DatePublished).Select(x => new PostListViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Summary = x.Summary,
                    DatePublished = x.DatePublished.Value,
                    UrlImage = x.UrlImage,
                    Permalink = x.Permalink
                });

            if (!paging.Page.HasValue)
                paging.Page = page;

            if (!paging.Size.HasValue)
                paging.Size = size;

            return query.Skip((paging.Page.Value * paging.Size.Value)).Take(paging.Size.Value);
        }

        public IEnumerable<PostListViewModel> GetByFilter(PagingFilter paging)
        {
            if (string.IsNullOrEmpty(paging.Filter))
                paging.Filter = string.Empty;

            var query = _context.Posts.Where(x => x.DatePublished != null && (x.Title.ToUpper().Contains(paging.Filter.ToUpper()) || x.Text.ToUpper().Contains(paging.Filter.ToUpper())))
                .OrderByDescending(x => x.DatePublished).Select(x => new PostListViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Summary = x.Summary,
                    DatePublished = x.DatePublished.Value,
                    UrlImage = x.UrlImage
                });

            if (!paging.Page.HasValue)
                paging.Page = page;

            if (!paging.Size.HasValue)
                paging.Size = size;

            return query.Skip((paging.Page.Value * paging.Size.Value)).Take(paging.Size.Value);
        }
    }
}