using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.Application.DTO
{
    public class DeliveryDTO
    {
        public Guid? Id { get; set; }
        public string? DeliveryName { get; set; }
        public string? DeliPhone { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }
        public bool? IsActive { get; set; }

        
    }
    
}
