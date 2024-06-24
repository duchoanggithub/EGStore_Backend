using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
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


        public Delivery Delivery { get; set; }
        public User User { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; } = new List<OrderProduct>();

    }
}
