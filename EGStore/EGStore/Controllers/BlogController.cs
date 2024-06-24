using EGStore.Application.DTO;
using EGStore.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EGStore.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        /// <summary>
        /// thêm mới role
        /// </summary>
        // <param name="blogDTO"></param>
        /// <returns></returns>
        /// 
        [HttpPost("Them")]
        public IActionResult AddBlog(BlogDTO blogDTO)
        {
            blogDTO.Id = Guid.NewGuid();
            if (_blogService.AddBlog(blogDTO))
            {
                return Conflict("bài viết này đã tồn tại");
            }
            return Ok(new { Message = "Thêm bài viết thành công", blogDTO });

        }

        /// <summary>
        /// lấy theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("LayTatCa")]
        public IActionResult GetAllBlogs()
        {

            return Ok(_blogService.GetAllBlogs());
        }

        /// <summary>
        /// tìm theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("TimKiem/{id:Guid}")]
        public IActionResult GetBlog(Guid id)
        {
            var nccs = _blogService.GetBlogById(id);
            if (nccs == null)
            {
                return NotFound();
            }
            return Ok(nccs);
        }

        /// <summary>
        /// cập nhật theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpPut("CapNhat/{id}")]
        public IActionResult UpdateBlog(Guid id, BlogDTO blogDTO)
        {
            if (_blogService.UpdateBlog(blogDTO))
            {
                return Ok(new { Mesasge = "Cập nhật thành công", blogDTO });
            }
            return NotFound(new { Mesasge = "Không tìm thấy bài viết để cập nhật" });
        }

        /// <summary>
        /// xóa theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("Xoa/{id:Guid}")]
        public IActionResult DeleteBlog(Guid id)
        {
            if (_blogService.DeleteBlog(id))
            {
                return Ok(new { message = "Xóa thành công.", id });
            }
            return NotFound(new { message = "Không thể xóa vì bài viết này không tồn tại." });
        }
    }
}

