using FizzWare.NBuilder;
using JmBlog.Controllers;
using JmBlog.Interfaces;
using JmBlog.Model;
using JmBlog.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
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
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.HttpContext.Request.Path = "/Path";
        }

        [Fact]
        public void MustCallServiceOnPost()
        {
            var request = new PostCreateViewModel() { Title = "Teste", Text = "Teste" };
            _mockService.Setup(x => x.Create(It.IsAny<PostCreateViewModel>()));

            var result = _controller.Post(request);

            _mockService.Verify(x => x.Create(It.IsAny<PostCreateViewModel>()), Times.Once);
            _mockService.VerifyNoOtherCalls();
            Assert.IsType<CreatedResult>(result);
        }

        [Fact]
        public void MustReturnBadRequestWhenModelIsInvalid()
        {
            var request = new PostCreateViewModel();
            _controller.ModelState.AddModelError("Title", "Error");
            _mockService.Setup(x => x.Create(It.IsAny<PostCreateViewModel>()));

            var result = _controller.Post(request);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        // [Fact]
        // public void GetPostById_OK_Response()
        // {
        //     var p =  Builder<Post>.CreateNew().Build();
        //     _mockService.Setup(x => x.GetById(1)).Returns(p);

        //     var getResult = _controller.Get(1);
        //     var result = getResult as OkObjectResult;
        //     var content = result.Value as Post;

        //     Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        //     Assert.NotNull(content);
        //     Assert.Equal(p.Id, content.Id);
        //     Assert.Equal(p.Title, content.Title);
        //     Assert.Equal(p.Summary, content.Summary);
        //     Assert.Equal(p.Text, content.Text);
        //     _mockService.Verify(x => x.GetById(1), Times.Once);

        // }

        // public void GetPostById_NotFound_Response()
        // {
        //     _mockService.Setup(x => x.GetById(1)).Returns((Post)null);

        //     var getResult = _controller.Get(1);
        //     var result = getResult as NotFoundResult;           

        //     Assert.Equal((int)HttpStatusCode.NotFound, result.StatusCode);            
            
        //     _mockService.Verify(x => x.GetById(1), Times.Once);

        // }
    }
}
