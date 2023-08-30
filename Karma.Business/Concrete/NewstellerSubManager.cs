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
    public class NewstellerSubManager : INewstellerSubService
    {
        private readonly INewstellerSubDal _newstellerSubDal;
        public NewstellerSubManager(INewstellerSubDal newstellerSubDal)
        {
            _newstellerSubDal = newstellerSubDal;
        }
        public void Add(NewstellerSub entity)
        {
            _newstellerSubDal.Add(entity);
        }

        public NewstellerSub Get(Expression<Func<NewstellerSub, bool>> filter = null)
        {
            return _newstellerSubDal.Get(filter);
        }

        public List<NewstellerSub> GetList(Expression<Func<NewstellerSub, bool>> filter = null)
        {
            return _newstellerSubDal.GetList(filter);
        }

        bool INewstellerSubService.IsExist(string email)
        {
            return _newstellerSubDal.Get(x => x.Email == email) != null ? true : false;
        }
    }
}
