using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Karma.Core.Entities;

namespace Karma.Entities.Concrete
{
    public class Spesification : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Depth { get; set; }
        public string Weight { get; set; }
        public bool QualityCheck { get; set; }
        public string FreshnessDuration { get; set; }
        public string WhenPacketing { get; set; }
        public string QuantityPerBox { get; set; }

        public Product Products { get; set; }
    }
}
