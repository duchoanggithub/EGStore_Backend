﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.Application.DTO
{
    public class CategoryDTO
    {
        public Guid? Id { get; set; }
        public string? CateProdName { get; set; }
        public string? Describe { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }
        public bool? IsActive { get; set; }

      
    }
}
