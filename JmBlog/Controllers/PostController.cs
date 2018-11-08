using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JmBlog.Interfaces;
using JmBlog.Model;
using JmBlog.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JmBlog.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class PostController : Controller
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return base.BadRequest("Model is invalid.");
            }

            try
            {
                var postId = await _postService.Create(viewModel);
                return base.Created(HttpContext.Request.Path + "/" + postId, new { id = postId });
            }
            catch (Exception ex)
            {
                return base.BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var obj = _postService.GetById(id);
            if (obj == null)
                return NotFound();

            return Ok(obj);
        }

        [HttpGet]
        [Route("Permalink/{permalink}")]
        public IActionResult GetByPermalink(string permalink)
        {
            var obj = _postService.GetByPermalink(permalink);
            if (obj == null)
                return NotFound();

            return Ok(obj);
        }

        [HttpGet]
        public IEnumerable<PostListViewModel> Get([FromQuery] PagingFilter paging)
        {
            return _postService.Get(paging);
        }
    }
}