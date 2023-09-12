using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Business.Abstract;
using Karma.Core.Aspects.Postsharp.CacheAspects;
using Karma.Core.Aspects.Postsharp.ExceptionsLogAspects;
using Karma.Core.CrossCuttingConcerns.Caching.Microsoft;
using Karma.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Karma.DataAccess.Abstract;
using Karma.Entities.Concrete;
using Microsoft.Extensions.Caching.Memory;

namespace Karma.Business.Concrete
{
    public class NewstellerSubManager : INewstellerSubService
    {
        private readonly INewstellerSubDal _newstellerSubDal;
        public NewstellerSubManager(INewstellerSubDal newstellerSubDal)
        {
            _newstellerSubDal = newstellerSubDal;
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Add(NewstellerSub entity)
        {
            _newstellerSubDal.Add(entity);
        }
        [CacheAspect(typeof(MemoryCacheManager), 60)]
        public NewstellerSub GetById(int Id)
        {
            return _newstellerSubDal.Get(x => x.Id == Id);
        }
        [CacheAspect(typeof(MemoryCacheManager), 60)]
        public List<NewstellerSub> GetAll()
        {
            return _newstellerSubDal.GetList();
        }
        public bool IsExist(string email)
        {
            return _newstellerSubDal.Get(x => x.Email == email) != null ? true : false;
        }
    }
}
