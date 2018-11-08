using JmBlog.Controllers;
using JmBlog.Interfaces;
using JmBlog.ViewModels;
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
            var request = new PostCreateViewModel();
            _mockService.Setup(x => x.Create(It.IsAny<PostCreateViewModel>()));

            _controller.Post(request);

            _mockService.Verify(x => x.Create(It.IsAny<PostCreateViewModel>()), Times.Once);
            _mockService.VerifyNoOtherCalls();
        }
    }
}
