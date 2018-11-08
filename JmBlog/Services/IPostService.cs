using JmBlog.Model;
using JmBlog.ViewModels;
using System.Collections.Generic;

namespace JmBlog.Interfaces
{
    public interface IPostService
    {
        int Create(PostCreateViewModel viewModel);
        Post GetById(int id);
        IEnumerable<PostListViewModel> Get(PagingFilter paging);
    }
}
