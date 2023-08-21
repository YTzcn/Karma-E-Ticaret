using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Entities.Concrete;

namespace Karma.Business.Abstract
{
    public interface IProductService
    {
        Product Get(Expression<Func<Product, bool>> filter = null);
        List<Product> GetList(Expression<Func<Product, bool>> filter = null);
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
        List<Product> GetByFilter(int? categoryId, int[]? brandId, string[]? color, string? lowerValue, string? upperValue, string? key);
    }
}
