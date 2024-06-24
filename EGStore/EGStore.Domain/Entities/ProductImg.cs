using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.Domain.Entities
{
    public class ProductImg
    {
        public Guid Id { get; set; }
        public Guid? ProdId { get; set; }
        public string? Img { get; set; }

        public Product Product { get; set; }
    }
}
