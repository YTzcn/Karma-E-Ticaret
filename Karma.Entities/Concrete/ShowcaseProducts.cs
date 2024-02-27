using Karma.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Entities.Concrete
{
    public class ShowcaseProducts : IEntity
    {
        public int Id { get; set; }
        public virtual Product Product { get; set; }
    }
}
