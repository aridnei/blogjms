using FizzWare.NBuilder;
using JmBlog.Data.Contracts;
using JmBlog.Model;
using JmBlog.Services;
using JmBlog.Tests.Controllers;
using JmBlog.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JmBlog.Tests.Services
{
    public class PostServiceTests
    {
        private readonly Mock<IPostRepository> _mockRepository;
        private readonly PostService _service;

        public PostServiceTests()
        {
            _mockRepository = new Mock<IPostRepository>();
            _service = new PostService(_mockRepository.Object);
        }

        [Fact]
        public async Task MustCallServiceOnCreate()
        {
            var request = new PostCreateViewModel() { Title = "Teste", Text = "<p>Teste</p>" };
            _mockRepository.Setup(x => x.Save(It.IsAny<Post>())).Returns(Task.FromResult(1));
            _mockRepository.Setup(x => x.GetPermalinks(It.IsAny<string>())).Returns(1);

            await _service.Create(request);

            _mockRepository.Verify(x => x.Save(It.IsAny<Post>()), Times.Once);
            _mockRepository.Verify(x => x.GetPermalinks(It.IsAny<string>()), Times.Once);
            _mockRepository.VerifyNoOtherCalls();
        }

        [Fact]
        public void GetPostById()
        {
            var p = Builder<Post>.CreateNew().Build();
            _mockRepository.Setup(x => x.GetById(1)).Returns(p);

            var post = _service.GetById(1);

            Assert.NotNull(post);

            _mockRepository.Verify(x => x.GetById(1), Times.Once);
        }

        [Fact]
        public void GetPostById_Null()
        {
            _mockRepository.Setup(x => x.GetById(1)).Returns((Post)null);

            var post = _service.GetById(1);

            Assert.Null(post);

            _mockRepository.Verify(x => x.GetById(1), Times.Once);
        }

        [Fact]
        public void ShouldReturnAllPosts()
        {
            var paging = new PagingFilter() { Page = 1, Size = 10, Filter = "" };
            _mockRepository.Setup(x => x.Get(It.IsAny<PagingFilter>()));

            _service.Get(paging);

            _mockRepository.Verify(x => x.Get(It.IsAny<PagingFilter>()));
            _mockRepository.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldReturnPostsByFilter()
        {
            var paging = new PagingFilter() { Filter = "Teste" };
            _mockRepository.Setup(x => x.Get(It.IsAny<PagingFilter>()));

            _service.Get(paging);

            _mockRepository.Verify(x => x.GetByFilter(It.IsAny<PagingFilter>()));
            _mockRepository.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldNotReturnPostsByEmptyFilter()
        {
            var paging = new PagingFilter();
            _mockRepository.Setup(x => x.Get(It.IsAny<PagingFilter>()));

            _service.Get(paging);

            _mockRepository.Verify(x => x.GetByFilter(It.IsAny<PagingFilter>()), Times.Never);
        }

        [Theory]
        [InlineData("permalink-teste")]
        [InlineData("permalink")]
        [InlineData("")]
        public void MustCallServiceOnGetByPermalink(string permalink)
        {
            _mockRepository.Setup(x => x.GetByPermalink(It.Is<string>(s => s.Equals(permalink)))).Returns(new Post());

            var result = _service.GetByPermalink(permalink);

            _mockRepository.Verify(x => x.GetByPermalink(It.Is<string>(s => s.Equals(permalink))), Times.Once);
            _mockRepository.VerifyNoOtherCalls();
        }
    }
}
