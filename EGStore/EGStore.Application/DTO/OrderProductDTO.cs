﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGStore.Application.DTO
{
    public class OrderProductDTO
    {
        public Guid Id { get; set; }
        public Guid? OrderId { get; set; }
        public Guid? ProdId { get; set; }
        public string? ProdName { get; set; }
        public double? Amount { get; set; }
        public double? UnitPrice { get; set; }
        public double? Sum { get; set; }
        public DateTime? CreateDay { get; set; }
        public DateTime? UpdateDay { get; set; }
        public bool? Status { get; set; }

        
    }
}
