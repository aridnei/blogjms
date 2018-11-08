using System.Collections.Generic;
using System.Threading.Tasks;
using JmBlog.Model;
using JmBlog.ViewModels;

namespace JmBlog.Data.Contracts
{
    public interface IPostRepository
    {
        Task Save(Post post);
        Post GetById(int postId);
        IEnumerable<PostListViewModel> Get(PagingFilter paging);
        IEnumerable<PostListViewModel> GetByFilter(PagingFilter paging);
    }
}