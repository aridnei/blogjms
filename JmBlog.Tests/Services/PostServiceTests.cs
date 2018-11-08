﻿using JmBlog.Data.Contracts;
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
        public void ShouldReturnAllPosts()
        {
            var paging = new PagingFilter() { page = 1, pageSize = 10, search = "" };
            _mockRepository.Setup(x => x.Get(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));

            _service.Get(paging);

            _mockRepository.Verify(x => x.Get(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), Times.Once));
            _mockRepository.VerifyNoOtherCalls();
        }

        [Fact]
        public void ShouldReturnPostsBySearch()
        {
            var paging = new PagingFilter() { page = 0, pageSize = 0, search = "Teste" };
            _mockRepository.Setup(x => x.Get(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));

            _service.Get(paging);

            _mockRepository.Verify(x => x.Get(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), Times.Once));
            _mockRepository.VerifyNoOtherCalls();
        }
    }
}
