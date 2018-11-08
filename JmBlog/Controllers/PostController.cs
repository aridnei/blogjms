using System;
using JmBlog.Interfaces;
using JmBlog.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JmBlog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PostCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return base.BadRequest("Model is invalid.");
            }

            try
            {
                var post = _postService.Create(viewModel);
                return base.Created(HttpContext.Request.Path + "/" + post.Id, post);
            }
            catch (Exception ex)
            {
                return base.BadRequest(ex.Message);
            }
        }
    }
}