using System.Linq.Expressions;
using System.Net.Http.Headers;
using Karma.Core.DataAccess;
using Karma.Entities.Concrete;

namespace Karma.DataAccess
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<Product> GetDetailsList(Expression<Func<Product, bool>> filter = null);
        Product GetDetails(Expression<Func<Product, bool>> filter = null);
    }
}