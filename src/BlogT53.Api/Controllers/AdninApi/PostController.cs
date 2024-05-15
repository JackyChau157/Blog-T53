using AutoMapper;
using BlogT53.Core.Domain.Content;
using BlogT53.Core.Models;
using BlogT53.Core.Models.Content;
using BlogT53.Core.SeedWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogT53.Api.Controllers.AdninApi
{
    [Route("api/admin/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PostDto>> GetPostByIdAsync(Guid id)
        {
            var post = await _unitOfWork.Posts.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpGet]
        [Route("paging")]
        public async Task<ActionResult<PagedResult<PostInListDto>>> GetPostPagingAsync(string? keyword, Guid? categoryId, int pageIndex, int pageSize = 10)
        {
            var result = await _unitOfWork.Posts.GetPostsPagingAsync(keyword, categoryId, pageIndex, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePost([FromBody] CreateUpdatePostRequest request)
        {
            var post = _mapper.Map<CreateUpdatePostRequest, Post>(request);
            _unitOfWork.Posts.Add(post);

            var result = await _unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePost(Guid id, [FromBody] CreateUpdatePostRequest request)
        {
            var post = await _unitOfWork.Posts.GetByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _mapper.Map(request, post);
            var result = await _unitOfWork.CompleteAsync();

            return result > 0 ? Ok() : BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePosts([FromQuery] Guid[] ids)
        {
            foreach (var id in ids)
            {
                var post = await _unitOfWork.Posts.GetByIdAsync(id);
                if (post == null)
                {
                    return NotFound();
                }
                _unitOfWork.Posts.Remove(post);
            }
            var result = await _unitOfWork.CompleteAsync();
            return result > 0 ? Ok() : BadRequest();
        }
    }
}