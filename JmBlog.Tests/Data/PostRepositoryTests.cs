using FizzWare.NBuilder;
using JmBlog.Controllers;
using JmBlog.Data;
using JmBlog.Data.Contracts;
using JmBlog.Interfaces;
using JmBlog.Model;
using JmBlog.ViewModels;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JmBlog.Tests.Data
{
    public class PostRepositoryTests : IDisposable
    {
        private Mock<IPostService> _mockService;
        private PostRepository _postRepository;

        private BlogContext _ctx;
        private int OneId = 0;

        public PostRepositoryTests()
        {
            _ctx = GetInMemoryDB();
            _postRepository = new PostRepository(_ctx);
            Task.Run(() => PopulateDB()).Wait();
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _postRepository = null;
            _ctx = null;
        }

        [Fact]
        public async Task Save()
        {
            var p = Builder<Post>.CreateNew().With(x => x.Id, 0).With(pp => pp.Title, "Meu titulo para teste").Build();
            await _postRepository.Save(p);
            var mPost = await _ctx.Posts.FirstOrDefaultAsync(x => x.Id == p.Id);
            Assert.NotNull(mPost);
            Assert.Equal("Meu titulo para teste", mPost.Title);
        }

        [Fact]
        public void GetById_Ok()
        {
            var post = _postRepository.GetById(OneId);
            Assert.NotNull(post);
        }

        [Fact]
        public void GetById_Null()
        {
            var post = _postRepository.GetById(100);
            Assert.Null(post);
        }

        [Fact]
        public void Should_Return_Posts_Where_Size_And_Page_IsNull()
        {
            var paging = new PagingFilter();

            var posts = _postRepository.Get(paging);
            Assert.NotNull(posts);
        }

        [Fact]
        public void Should_Return_Total_Posts_Equals_Size()
        {
            var paging = new PagingFilter() { Size = 5 };

            var posts = _postRepository.Get(paging);
            Assert.Equal(5, posts.Count());
        }

        [Fact]
        public void Should_Return_Zero_Posts_Where_Page_Greather_Than_Total_Itens()
        {
            var paging = new PagingFilter() { Page = 1 };

            var posts = _postRepository.Get(paging);
            Assert.Equal(0, posts.Count());
        }

        private async Task PopulateDB()
        {
            var posts = Builder<Post>.CreateListOfSize(10).All().With(x => x.Id, 0).Build().ToList();
            foreach(var p in posts){
                await _postRepository.Save(p);
                OneId = p.Id;
            }
        }

        private BlogContext GetInMemoryDB()
        {
            DbContextOptions<BlogContext> options;
            var b = new DbContextOptionsBuilder<BlogContext>();
            b.UseInMemoryDatabase("DemoMemory" + new string[] { }.GetHashCode().ToString(), null);
            options = b.Options;
            return new BlogContext(options);
        }

        
    }
}
