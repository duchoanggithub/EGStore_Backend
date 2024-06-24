using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.Domain.Entities
{
    public class BlogImg
    {
        public Guid Id { get; set; }
        public Guid? BlogId { get; set; }
        public string? Img { get; set; }

        public Blog Blog { get; set; }
    }
}
