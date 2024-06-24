using EGStore.Application.DTO;
using EGStore.Application.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using EGStore.Application.DTO.Authen;
using Microsoft.AspNetCore.Authorization;

namespace EGStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;


        public AuthenController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;

        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDTO registerDTO)
        {
            // Kiểm tra tính hợp lệ của RegisterDTO
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Thông tin người dùng không hợp lệ." });
            }

            // Kiểm tra xác nhận mật khẩu
            if (registerDTO.Password != registerDTO.ConfirmPassword)
            {
                return BadRequest(new { Message = "Xác nhận mật khẩu không chính xác." });
            }

            // Kiểm tra xem tên tài khoản đã tồn tại chưa
            if (_userService.GetAllUsers().Any(x => x.UserName == registerDTO.UserName))
            {
                return BadRequest(new { Message = "Tên tài khoản đã tồn tại." });
            }

            // Tạo một UserDTO từ RegisterDTO
            var userDTO = new UserDTO
            {
                Id = Guid.NewGuid(),
                UserName = registerDTO.UserName,
                Password = registerDTO.Password,
                Email = registerDTO.Email,
                CreateDay = DateTime.Now,
                UpdateDay = DateTime.Now,
                IsActive = true
            };

            // Thêm người dùng vào cơ sở dữ liệu
            if (_userService.AddUser(userDTO))
            {
                // Trường hợp không thành công
                return BadRequest(new { Message = "Đăng ký không thành công" });
            }
            // Đăng ký thành công, trả về thông báo
            return Ok(new { Message = "Đăng ký thành công" });
        }


        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {

            if (loginDTO?.UserName == null || loginDTO?.Password == null)
            {
                return Unauthorized();
            }
            // Tạo một đối tượng UserDTO từ LoginDTO để kiểm tra đăng nhập
            var userDTO = new UserDTO
            {
                UserName = loginDTO.UserName,
                Password = loginDTO.Password
            };

            var secretKey = _configuration["JWT:Secret"];
            if (secretKey == null)
            {
                return Unauthorized();
            }

            var user = _userService.GetAllUsers().Find(x => x.UserName == userDTO.UserName && x.Password == userDTO.Password);
            var role = _userService.GetRoleByUserName(userDTO.UserName);

            if (user != null)
            {

                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

                var signingCredential = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new(ClaimTypes.Name, userDTO.UserName),
                    new Claim("sub", userDTO.UserName)
                };

                // Chỉ thêm ClaimTypes.Role nếu role.RoleName có giá trị
                if (role?.RoleName != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
                }

                var token = new JwtSecurityToken
                (
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signingCredential,
                    claims: claims
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                // Sinh ra chuỗi token với các thông số ở trên
                return Ok(new
                {
                    token = tokenString,
                    userName = user.UserName,
                    role = role?.RoleName
                });
            }

            return Unauthorized();
        }
    }
}