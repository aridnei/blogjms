using System.Threading.Tasks;
using System.Linq;
using JmBlog.Model;
using JmBlog.Data.Contracts;

namespace JmBlog.Data
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogContext _context;
        public PostRepository(BlogContext context)
        {
            this._context = context;
        }

        public async Task Save(Post post){
            await _context.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public Post GetById(int postId)
        {
            return _context.Posts.FirstOrDefault(p => p.Id == postId);
        }
    }
}