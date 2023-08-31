using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Core.Entities;

namespace Karma.Entities.Concrete
{
    public class NewstellerSub : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; } = true;
    }
}
