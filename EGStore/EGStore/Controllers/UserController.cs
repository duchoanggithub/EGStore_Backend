using EGStore.Application.DTO;
using EGStore.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EGStore.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        /// <summary>
        /// Thêm user 
        /// </summary>
        // <param name="userDTO"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult AddUser(UserDTO userDTO)
        {
            var existingUser = _userService.GetAllUsers().FirstOrDefault(x => x.UserName == userDTO.UserName);

            if (existingUser != null)
            {

                return BadRequest(new { Message = "Tài khoản đã tồn tại" });
            }


            userDTO.RoleId = Guid.Parse("9eff75f6-7a81-4a67-9fbf-75a0deab0828");
            userDTO.Id = Guid.NewGuid();

            if (_userService.AddUser(userDTO))
            {
                // Trường hợp không thành công
                return BadRequest(new { Message = "Không thể tạo tài khoản" });
            }
            return CreatedAtAction("AddUser", new { id = userDTO.Id },
                new { Message = "Tạo tài khoản thành công", userDTO.Id });
        }

        /// <summary>
        /// lấy tất cả theo Id 
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "Admin")]
        [HttpGet("LayTatCa")]
        public IActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet("GetUserByUserName")]
        public IActionResult GetUserByUserName(string userName)
        {
            var user = _userService.GetAllUsers().FirstOrDefault(u => u.UserName == userName);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }


        [HttpGet("TimKiem/{id:Guid}")]
        public IActionResult GetUserById(Guid id)
        {
            var user = _userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /// <summary>
        /// sửa theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpPut("CapNhat/{id}")]
        public IActionResult UpdateUser(Guid id, UserDTO userDTO)
        {
            if (_userService.UpdateUser(userDTO))
            {
                return Ok(new { Mesasge = "Cập nhật thành công", userDTO });
            }
            return NotFound(new { Mesasge = "Không tìm thấy người dùng để cập nhật" });
        }

        /// <summary>
        /// xóa theo Id
        /// </summary>
        // <param name="id"></param>
        /// <returns></returns>
        /// 
        [Authorize(Roles = "Admin")]
        [HttpDelete("Xoa/{id:Guid}")]
        public IActionResult DeleteUser(Guid id)
        {
            if (_userService.DeleteUser(id))
            {
                return Ok(new { message = "Xóa thành công.", id });
            }
            return NotFound(new { message = "Không thể xóa vì người dùng này không tồn tại." });
        }
    }
}
