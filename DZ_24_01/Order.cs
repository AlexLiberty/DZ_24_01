﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_24_01
{
    internal class Order
    {
        public int Id {  get; set; }
        public string? Fio {  get; set; }
        public string? Address { get; set; }
        public List<OrderLine> OrderLines { get; set; } = new();
    }
}
