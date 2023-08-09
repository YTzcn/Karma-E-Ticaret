using Karma.Core.Entities;

namespace Karma.Entities
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ImagePath { get; set; }
        public bool Active { get; set; }
    }
}