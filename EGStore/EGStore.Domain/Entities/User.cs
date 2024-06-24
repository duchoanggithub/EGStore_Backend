using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EGStore.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid? RoleId { get; set; }
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

        public Role Role { get; set; }
        public ICollection<Order>? Orders { get; set; } = new List<Order>();

    }
}
