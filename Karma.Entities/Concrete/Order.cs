using Karma.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Karma.Entities.Concrete
{

    public class Order : IEntity
    {
        [Key]
        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public string UserId { get; set; }
        public DateTime Date => DateTime.Now;
        public byte Status { get; set; }
        public string Detail { get; set; }

    }
}
