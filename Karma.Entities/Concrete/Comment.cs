using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Core.Entities;

namespace Karma.Entities.Concrete
{
    public class Comment : IEntity
    {
        public Comment()
        {
            AddedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Username { get; set; }
        public string EMail { get; set; }
        public string CommentContext { get; set; }
        public DateTime AddedDate { get; set; }

        public Product Products { get; set; }
    }
}
