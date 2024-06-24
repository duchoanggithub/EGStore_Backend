using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.Application.DTO
{
    public class SupplierDTO
    {
        public Guid Id { get; set; }
        public string? SupName { get; set; }
        public string? ContactPerson { get; set; }
        public string? PhoneContact { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }
        public bool? IsActive { get; set; }
    }
}
