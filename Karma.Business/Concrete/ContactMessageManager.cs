using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Business.Abstract;
using Karma.Core.Aspects.Postsharp.CacheAspects;
using Karma.Core.Aspects.Postsharp.LogAspects;
using Karma.Core.CrossCuttingConcerns.Caching.Microsoft;
using Karma.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Karma.DataAccess.Abstract;
using Karma.Entities.Concrete;

namespace Karma.Business.Concrete
{
    [LogAspect(typeof(FileLogger))]

    public class ContactMessageManager : IContactService
    {
        private readonly IContactMessageDal _contactMessageDal;
        public ContactMessageManager(IContactMessageDal contactMessageDal)
        {
            _contactMessageDal = contactMessageDal;
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]

        public void Add(ContactMessage entity)
        {
            _contactMessageDal.Add(entity);
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]

        public void Delete(ContactMessage entity)
        {
            _contactMessageDal.Delete(entity);
        }
        [CacheAspect(typeof(MemoryCacheManager), 60)]

        public ContactMessage GetById(int Id)
        {
            return _contactMessageDal.Get(x => x.Id == Id);
        }
        [CacheAspect(typeof(MemoryCacheManager), 60)]

        public List<ContactMessage> GetAll()
        {
            return _contactMessageDal.GetList();
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Update(ContactMessage entity)
        {
            _contactMessageDal.Update(entity);
        }
    }
}
