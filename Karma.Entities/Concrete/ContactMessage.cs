using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Core.Entities;

namespace Karma.Entities.Concrete
{
    public class ContactMessage : IEntity
    {
        public ContactMessage()
        {
            AddedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string IpAddress { get; set; }
        public DateTime AddedDate { get; set; }


    }
}
