using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Entities.Concrete;

namespace Karma.Business.Abstract
{
    public interface INewstellerSubService
    {
        public void Add(NewstellerSub entity);
        public List<NewstellerSub> GetList(Expression<Func<NewstellerSub, bool>> filter = null);
        public NewstellerSub Get(Expression<Func<NewstellerSub, bool>> filter = null);
        public bool IsExist(string email);
    }
}
