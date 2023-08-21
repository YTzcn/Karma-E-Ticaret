using System.Linq.Expressions;
using System.Net.Http.Headers;
using Karma.Core.DataAccess;
using Karma.Entities.Concrete;

namespace Karma.DataAccess
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<Product> GetList(Expression<Func<Product, bool>> filter = null);
        Product Get(Expression<Func<Product, bool>> filter = null);
    }
}