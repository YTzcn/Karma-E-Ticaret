using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Core.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Karma.Entities.Concrete
{

    public class Order : IEntity
    {
        [Key]
        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }
        public DateTime Date => DateTime.Now;
        public bool Active { get; set; }
        public string Detail { get; set; }

    }
}
