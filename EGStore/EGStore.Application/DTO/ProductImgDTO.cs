﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.Application.DTO
{
    public class ProductImgDTO
    {
        public Guid Id { get; set; }
        public Guid? ProdId { get; set; }
        public string? Img { get; set; }
    }
}