using System.Threading.Tasks;
using JmBlog.Model;

namespace JmBlog.Data.Contracts
{
    public interface IPostRepository
    {
         Task Save(Post post);
    }
}