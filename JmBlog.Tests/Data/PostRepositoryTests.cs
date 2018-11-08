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
using Xunit2.Should;

namespace JmBlog.Tests.Data
{
    public class PostRepositoryTests : IDisposable
    {
        private Mock<IPostService> _mockService;
        private PostRepository _postRepository;

        private BlogContext _ctx;
        private int OneId = 0;
        private string PermalinkTest = string.Empty;

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
        public void GetByPermalink_Ok()
        {
            var post = _postRepository.GetByPermalink(PermalinkTest);
            Assert.NotNull(post);
        }

        [Fact]
        public void GetByPermalink_Null()
        {
            var post = _postRepository.GetByPermalink("um-permalink-teste");
            Assert.Null(post);
        }

        [Fact]
        public void GetByPermalinks_WithResult()
        {
            var count = _postRepository.GetPermalinks(PermalinkTest);
            (count).ShouldBe(1);
        }

        [Fact]
        public void GetByPermalinks_WithoutResult()
        {
            var count = _postRepository.GetPermalinks("um-permalink-teste");
            (count).ShouldBe(0);
        }

        private async Task PopulateDB()
        {
            var posts = Builder<Post>.CreateListOfSize(10).All().With(x => x.Id, 0).TheLast(1).With(x => x.Permalink, "permalink-teste").Build().ToList();
            foreach(var p in posts){
                await _postRepository.Save(p);
                OneId = p.Id;
                PermalinkTest = p.Permalink;
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
