using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EGStore.Application.DTO;
using EGStore.Application.Interface;
using EGStore.Domain.Entities;
using EGStore.Domain.Repositories;

namespace EGStore.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo; //gọi thông qua Interface
        private readonly IMapper _mapper;
        private readonly IRoleRepo _roleRepo;

        public UserService(IUserRepo userRepo, IMapper mapper, IRoleRepo roleRepo)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _roleRepo = roleRepo;
        }
        public RoleDTO GetRoleByUserName(string userName)
        {
            var userRole = _userRepo.GetAll()
            .Where(u => u.UserName == userName)
            .Join(_roleRepo.GetAll(), u => u.RoleId, r => r.Id, (u, r) => r)
            .FirstOrDefault();

            if (userRole != null)
            {
                return ConvertToRoleDto(userRole);
            }

            return null;
        }

        private static RoleDTO ConvertToRoleDto(Role role)
        {
            if (role != null)
            {
                return new RoleDTO
                {
                    RoleName = role.RoleName,
                    // Các trường khác của RoleDto nếu có
                };
            }

            // Trả về một RoleDto mặc định hoặc null tùy vào yêu cầu
            return null;
        }
        public List<UserDTO> GetAllUsers()
        {
            return _mapper.Map<List<UserDTO>>(_userRepo.GetAll());
        }

        public UserDTO GetUser(Guid id)
        {
            return _mapper.Map<UserDTO>(_userRepo.Get(id));
        }

        public UserDTO GetUserByUserName(string userName)
        {
            return _mapper.Map<UserDTO>(_userRepo.GetAll().FirstOrDefault(u => u.UserName == userName));
        }

        public bool AddUser(UserDTO userDTO)
        {
            return _userRepo.Add(_mapper.Map<User>(userDTO));
        }

        public bool UpdateUser(UserDTO userDTO)
        {
            return _userRepo.Update(_mapper.Map<User>(userDTO));
        }

        public bool DeleteUser(Guid id)
        {
            return _userRepo.Delete(id);
        }

    }
}
