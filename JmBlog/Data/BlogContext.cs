using JmBlog.Model;
using Microsoft.EntityFrameworkCore;

namespace JmBlog.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            
        }

        public DbSet<Post> Posts { get; set; }
    }
}