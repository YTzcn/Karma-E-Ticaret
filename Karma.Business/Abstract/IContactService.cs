using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Entities.Concrete;

namespace Karma.Business.Abstract
{
    public interface IContactService
    {
        public List<ContactMessage> GetList(Expression<Func<ContactMessage, bool>> filter = null);
        public ContactMessage Get(Expression<Func<ContactMessage, bool>> filter = null);
        public void Add(ContactMessage entity);
        public void Update(ContactMessage entity);
        public void Delete(ContactMessage entity);
    }
}
