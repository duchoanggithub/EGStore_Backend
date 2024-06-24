using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.Application.DTO
{
    public class BlogDTO
    {
        public Guid? Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Content { get; set; }
        public string? BlogImg { get; set; }
        public DateTime? UpDay { get; set; }
        public DateTime? UpdateDay { get; set; }
        public bool? IsActive { get; set; }


    }
}
