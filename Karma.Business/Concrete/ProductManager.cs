using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Karma.Business.Abstract;
using Karma.DataAccess;
using Karma.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace Karma.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }
        public Product Get(Expression<Func<Product, bool>> filter = null)
        {
            return _productDal.GetDetails(filter);
        }

        public List<Product> GetList(Expression<Func<Product, bool>> filter = null)
        {
            return _productDal.GetDetailsList(filter);
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public List<Product> GetByFilter(int? categoryId, int[]? brandId, string[]? color, string? lowerValue, string? upperValue, string? key)
        {
            var products = _productDal.GetDetailsList();
            if (!String.IsNullOrEmpty(key))
            {
                products = products.Where(x => x.ProductName.ToLower().Contains(key.ToLower())).ToList();
            }
            if (brandId.Length != 0)
            {
                products = products.Where(x => brandId.Contains(x.BrandId)).ToList();
            }
            if (color.Length != 0)
            {
                products = products.Where(x => color.Contains(x.Color)).ToList();
            }
            if (!String.IsNullOrEmpty(lowerValue))
            {
                products = products.Where(x => x.Price > Convert.ToDecimal(lowerValue)).ToList();
            }
            if (!String.IsNullOrEmpty(upperValue))
            {
                products = products.Where(x => x.Price < Convert.ToDecimal(upperValue)).ToList();
            }
            if (!String.IsNullOrEmpty(lowerValue) && !String.IsNullOrEmpty(upperValue))
            {
                products = products.Where(x => Convert.ToDecimal(lowerValue) < x.Price && x.Price < Convert.ToDecimal(upperValue)).ToList();
            }
            if (categoryId != null)
            {
                if (categoryId != 0)
                    products = products.Where(x => x.CategoryId == categoryId).ToList();
            }

            return products;
        }
    }
}
