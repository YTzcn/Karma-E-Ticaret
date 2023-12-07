using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Core.Entities;

namespace Karma.Entities.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public string UserId { get; set; }
        public DateTime Date => DateTime.Now;
        public string Detail { get; set; }

    }
}
