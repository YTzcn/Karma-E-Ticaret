using Karma.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Entities.Concrete
{
    public class CampaignProduct : IEntity
    {
        public int Id { get; set; }
        public virtual Product Product { get; set; }
        public double NewPrice { get; set; }
        public bool Active { get; set; }
    }
}
