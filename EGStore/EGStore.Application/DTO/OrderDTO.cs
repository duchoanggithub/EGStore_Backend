using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.Application.DTO
{
    public class OrderDTO
    {
        public Guid? Id { get; set; }
        public Guid? UserId { get; set; }
        public Guid? DeliveryId { get; set; }
        public string? CusName { get; set; }
        public string? CusPhone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? NotePay { get; set; }
        public string? PaymentMenthods { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }
        public bool? Status { get; set; }


    }
}
