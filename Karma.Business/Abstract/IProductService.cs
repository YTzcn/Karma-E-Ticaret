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
        Product GetById(int Id);
        Product GetByProductName(string ProductName);
        List<Product> GetListByCategory(int categoryId);
        List<Product> GetAll();
        List<Product> GetListByBrandId(int brandId);
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
        List<Product> GetByFilter(int? categoryId, int[]? brandId, string[]? color, string? lowerValue, string? upperValue, string? key);
        List<Product> GetProductLessThan5Quantity();
        List<Product> OutOfStock();
        List<Product> GetUpcomingProducts();
    }
}
