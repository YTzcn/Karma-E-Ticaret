using System.Linq.Expressions;
using System.Net.Http.Headers;
using Karma.Core.DataAccess;
using Karma.Entities.Concrete;

namespace Karma.DataAccess
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<Product> GetAllProd(Expression<Func<Product, bool>> filter = null);
    }
}