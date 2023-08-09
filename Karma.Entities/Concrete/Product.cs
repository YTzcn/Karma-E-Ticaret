﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Core.Entities;

namespace Karma.Entities.Concrete
{
    public class Product : IEntity
    {

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string SubDescription { get; set; }
        public int UnitInStock { get; set; }
        public string Color { get; set; }
        public bool Active { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        public List<Image> Images { get; set; }
    }
}
