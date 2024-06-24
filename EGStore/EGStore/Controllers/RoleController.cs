using EGStore.Application.DTO;
using EGStore.Application.Interface;
using EGStore.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EGStore.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// thêm mới role
        /// </summary>
        // <param name="RoleDTO"></param>
        /// <returns></returns>
        /// 
        [HttpPost("Them")]
        public IActionResult AddRole(RoleDTO roleDTO)
        {
            roleDTO.Id = Guid.NewGuid();
            if (_roleService.AddRole(roleDTO))
            {
                return BadRequest(new { Message = "Thêm quyền không thành công. Vai trò đã tồn tại hoặc có lỗi" });
            }
            return Ok(new { Message = "Thêm quyền thành công",  roleDTO });
        }
        /// <summary>
        /// lấy theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("LayTatCa")]
        public IActionResult GetAllRoles()
        {

            return Ok(_roleService.GetAllRoles());
        }

        /// <summary>
        /// tìm theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("TimKiem/{id:Guid}")]
        public IActionResult GetRole(Guid id)
        {
            var nccs = _roleService.GetRole(id);
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
        public IActionResult UpdateRole(Guid id, RoleDTO roleDTO)
        {
            if (_roleService.UpdateRole(roleDTO))
            {
                return Ok(new { Mesasge = "Cập nhật thành công", roleDTO });
            }
                return NotFound(new { Mesasge = "Không tìm thấy quyền để để cập nhật" });
        }

        /// <summary>
        /// xóa theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpDelete("Xoa/{id:Guid}")]
        public IActionResult DeleteRole(Guid id)
        {
            if (_roleService.DeleteRole(id))
            {
                return Ok(new { message = "Xóa thành công.", id });
            }
            return NotFound(new { message = "Không thể xóa vì quyền này không tồn tại." });
        }
    }
}
