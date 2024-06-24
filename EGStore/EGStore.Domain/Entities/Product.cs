using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.Domain.Entities
{
    public class Product
    {
        public Guid? Id { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? SupId { get; set; }
        public string? ProdCode { get; set; }
        public string? ProdName { get; set; }
        public double? Price { get; set; }
        public double? Discount { get; set; }
        public double? Inventory { get; set; }
        public string? ProdImg { get; set; }
        public string? Color { get; set; }
        public string? Origin { get; set; }
        public bool? Sex { get; set; }
        public string? Designs { get; set; }
        public string? FrameMaterial { get; set; }
        public string? Suitable { get; set; }
        public string? Describe { get; set; }
        public bool? UV { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }
        public bool? Status { get; set; }

        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<ProductImg>? ProductImgs { get; set; } = new List<ProductImg>();
        public ICollection<OrderProduct>? OrderProducts{ get; set; } = new List<OrderProduct>();

    }
}
