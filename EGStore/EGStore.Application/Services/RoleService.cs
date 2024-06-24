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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepo _roleRepo; //gọi thông qua Interface
        private readonly IMapper _mapper;
        public RoleService(IRoleRepo roleRepo, IMapper mapper)
        {
            _roleRepo = roleRepo;
            _mapper = mapper;
        }
        public List<RoleDTO> GetAllRoles()
        {
            return _mapper.Map<List<RoleDTO>>(_roleRepo.GetAll());
        }

        public RoleDTO GetRole(Guid id)
        {
            return _mapper.Map<RoleDTO>(_roleRepo.Get(id));
        }

        public bool AddRole(RoleDTO roleDTO)
        {
            return _roleRepo.Add(_mapper.Map<Role>(roleDTO));
        }

        public bool UpdateRole(RoleDTO roleDTO)
        {
            return _roleRepo.Update(_mapper.Map<Role>(roleDTO));
        }

        public bool DeleteRole(Guid id)
        {
            return _roleRepo.Delete(id);
        }
    }
}
