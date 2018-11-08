using JmBlog.ViewModels;

namespace JmBlog.Interfaces
{
    public interface IPostService
    {
        int Create(PostCreateViewModel viewModel);
    }
}
