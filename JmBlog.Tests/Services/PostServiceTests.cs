﻿using FizzWare.NBuilder;
using JmBlog.Data.Contracts;
using JmBlog.Model;
using JmBlog.Services;
using JmBlog.Tests.Controllers;
using JmBlog.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
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
        public void MustCallServiceOnCreate()
        {
            var request = new PostCreateViewModel() { Title = "Teste", Text = "Teste" };
            _mockRepository.Setup(x => x.Save(It.IsAny<Post>()));

            _service.Create(request);

            _mockRepository.Verify(x => x.Save(It.IsAny<Post>()), Times.Once);
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
    }
}
