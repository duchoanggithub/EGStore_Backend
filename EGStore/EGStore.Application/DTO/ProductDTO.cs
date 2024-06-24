using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.Application.DTO
{
    public class ProductDTO
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

        public void GenerateProdCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            ProdCode = new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
