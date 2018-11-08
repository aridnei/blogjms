using JmBlog.Controllers;
using JmBlog.Interfaces;
using JmBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JmBlog.Tests.Controllers
{
    public class PostControllerTests
    {
        private readonly Mock<IPostService> _mockService;
        private readonly PostController _controller;

        public PostControllerTests()
        {
            _mockService = new Mock<IPostService>();
            _controller = new PostController(_mockService.Object);
        }

        [Fact]
        public void MustCallServiceOnPost()
        {
            var request = new PostCreateViewModel() { Title = "Teste", Text = "Teste" };
            _mockService.Setup(x => x.Create(It.IsAny<PostCreateViewModel>()));

            var result = _controller.Post(request);

            _mockService.Verify(x => x.Create(It.IsAny<PostCreateViewModel>()), Times.Once);
            _mockService.VerifyNoOtherCalls();
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void MustReturnBadRequestWHenModelIsInvalid()
        {
            var request = new PostCreateViewModel();
            _mockService.Setup(x => x.Create(It.IsAny<PostCreateViewModel>()));

            var result = _controller.Post(request);

            _mockService.Verify(x => x.Create(It.IsAny<PostCreateViewModel>()), Times.Once);
            _mockService.VerifyNoOtherCalls();
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void ShouldReturnOkResponseFromAllPosts()
        {
            var request = new PagingFilter();
            _mockService.Setup(x => x.Get(It.IsAny<PagingFilter>()));

            var result = _controller.Get(request);

            _mockService.Verify(x => x.Create(It.IsAny<PagingFilter>()), Times.Once);
            _mockService.VerifyNoOtherCalls();
            Assert.IsType<OkResult>(result);
        }
    }
}
