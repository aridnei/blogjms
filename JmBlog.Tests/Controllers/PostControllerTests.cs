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
            var request = new Post();
            _mockService.Setup(x => x.Create(It.IsAny<Post>()));

            _controller.Post(request);

            _mockService.Verify(x => x.Create(It.IsAny<Post>()), Times.Once);
            _mockService.VerifyNoOtherCalls();
        }

        [Fact]
        public void MustThrowExceptionOnPost()
        {
            var request = new Post();
            _mockService.Setup(x => x.Create(It.IsAny<Post>())).Callback(()=> throw new Exception("Error") );

            Assert.Throws<Exception>(_controller.Post(request));

            _mockService.Verify(x => x.Create(It.IsAny<Post>()), Times.Once);
            _mockService.VerifyNoOtherCalls();
        }
    }
}
