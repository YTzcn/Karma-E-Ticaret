using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Core.Entities;

namespace Karma.Entities.Concrete
{
    public class Coupon : IEntity
    {
        public Coupon()
        {
            CreatedDate = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsSingleUse { get; set; }
        public decimal Price { get; set; }
    }
}
