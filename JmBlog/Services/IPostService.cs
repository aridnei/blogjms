using JmBlog.Model;
using JmBlog.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JmBlog.Interfaces
{
    public interface IPostService
    {
        Task<int> Create(PostCreateViewModel viewModel);
        Post GetById(int id);
        IEnumerable<PostListViewModel> Get(PagingFilter paging);
        Post GetByPermalink(string permalink);
    }
}
