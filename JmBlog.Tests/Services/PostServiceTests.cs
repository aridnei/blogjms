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
        private readonly PostService _service;

        public PostServiceTests()
        {
            _service = new PostService();
        }
    }
}
