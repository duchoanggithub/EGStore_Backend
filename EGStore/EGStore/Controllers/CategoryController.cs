using EGStore.Application.DTO;
using EGStore.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EGStore.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// thêm mới role
        /// </summary>
        // <param name="RoleDTO"></param>
        /// <returns></returns>
        /// 
        [HttpPost("Them")]
        public IActionResult AddCategory(CategoryDTO categoryDTO)
        {
            categoryDTO.Id = Guid.NewGuid();
            if (_categoryService.AddCategory(categoryDTO))
            {
                return Conflict("loại hàng này đã tồn tại");
            }
            return Ok(new { Message = "Thêm loại hàng thành công", categoryDTO });
        }

        /// <summary>
        /// lấy theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("LayTatCa")]
        public IActionResult GetAllCategorys()
        {

            return Ok(_categoryService.GetAllCategorys());
        }

        /// <summary>
        /// tìm theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("TimKiem/{id:Guid}")]
        public IActionResult GetCategory(Guid id)
        {
            var nccs = _categoryService.GetCategoryById(id);
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
        public IActionResult UpdateCategory(Guid id, CategoryDTO categoryDTO)
        {
            if (_categoryService.UpdateCategory(categoryDTO))
            {
                return Ok(new { message = "Cập nhật thành công.", categoryDTO});
            }
            return NotFound(new { message = "Không tìm thấy loại hàng để cập nhật." });
        }

        /// <summary>
        /// xóa theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("Xoa/{id:Guid}")]
        public IActionResult DeleteCategory(Guid id)
        {
            if (_categoryService.DeleteCategory(id))
            {
                return Ok(new { message = "Xóa thành công.", id });
            }
            return NotFound(new { message = "Không thể xóa vì loại hàng này không tồn tại." });
        }
    }
}
