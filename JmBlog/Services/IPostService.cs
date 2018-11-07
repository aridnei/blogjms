using JmBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JmBlog.Interfaces
{
    public interface IPostService
    {
        void Create(PostCreateViewModel viewModel);
    }
}
