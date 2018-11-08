using JmBlog.Data.Contracts;
using JmBlog.Services;
using JmBlog.Tests.Controllers;
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
    }
}
