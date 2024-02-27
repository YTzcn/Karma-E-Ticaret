using Karma.Core.DataAccess;
using Karma.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Karma.DataAccess.Abstract
{
    public interface IShowcaseProductsDal : IEntityRepository<ShowcaseProducts>
    {
        public ShowcaseProducts GetWithProduct(Expression<Func<ShowcaseProducts, bool>> filter = null);
        public List<ShowcaseProducts> GetAllList(Expression<Func<ShowcaseProducts, bool>> filter = null);
    }
}
