using Karma.Core.Entities;
using Karma.Entities.Concrete;

namespace Karma.Entities
{
    public class Image : IEntity
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public string Url { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public bool Active { get; set; }
        public Product Products { get; set; }
    }
}