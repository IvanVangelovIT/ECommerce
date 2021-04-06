﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Models.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public ICollection<Stock> Stocks { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
