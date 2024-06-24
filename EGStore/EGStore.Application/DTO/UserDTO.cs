using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EGStore.Application.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public Guid? RoleId { get; set; } = Guid.Parse("9eff75f6-7a81-4a67-9fbf-75a0deab0828") ;
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? AvatarUrl { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public bool? Sex { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }
        public bool? IsActive { get; set; }
        
    }
}
