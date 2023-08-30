using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Business.Abstract;
using Karma.DataAccess.Abstract;
using Karma.Entities.Concrete;

namespace Karma.Business.Concrete
{
    public class ContactMessageManager : IContactService
    {
        private readonly IContactMessageDal _contactMessageDal;
        public ContactMessageManager(IContactMessageDal contactMessageDal)
        {
            _contactMessageDal = contactMessageDal;
        }
        public void Add(ContactMessage entity)
        {
            _contactMessageDal.Add(entity);
        }

        public void Delete(ContactMessage entity)
        {
            _contactMessageDal.Delete(entity);
        }

        public ContactMessage Get(Expression<Func<ContactMessage, bool>> filter = null)
        {
            return _contactMessageDal.Get(filter);
        }

        public List<ContactMessage> GetList(Expression<Func<ContactMessage, bool>> filter = null)
        {
            return _contactMessageDal.GetList(filter);
        }

        public void Update(ContactMessage entity)
        {
            _contactMessageDal.Update(entity);
        }
    }
}
