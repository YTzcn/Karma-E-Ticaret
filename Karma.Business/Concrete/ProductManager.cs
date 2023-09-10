using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Karma.Business.Abstract;
using Karma.Business.ValidationRules.FluentValidation;
using Karma.Core.Aspects.Postsharp;
using Karma.Core.Aspects.Postsharp.CacheAspects;
using Karma.Core.Aspects.Postsharp.LogAspects;
using Karma.Core.Aspects.Postsharp.ValidationAspects;
using Karma.Core.CrossCuttingConcerns.Caching.Microsoft;
using Karma.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Karma.DataAccess;
using Karma.Entities.Concrete;

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
        public void Update(Product product)
        {
            _productDal.Update(product);
        }
        [LogAspect(typeof(DatabaseLogger))]
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
        [LogAspect(typeof(DatabaseLogger))]
        public Product GetById(int Id)
        {
            return _productDal.GetDetails(x => x.ProductId == Id);
        }
        [LogAspect(typeof(DatabaseLogger))]
        public Product GetByProductName(string ProductName)
        {
            return _productDal.GetDetails(x => x.ProductName == ProductName);
        }
        [LogAspect(typeof(DatabaseLogger))]
        public List<Product> GetListByCategory(int categoryId)
        {
            return _productDal.GetDetailsList(x => x.CategoryId == categoryId);
        }
        public List<Product> GetAll()
        {
            return _productDal.GetDetailsList();
        }
        [LogAspect(typeof(DatabaseLogger))]
        public List<Product> GetListByBrandId(int brandId)
        {
            return _productDal.GetDetailsList(x => x.BrandId == brandId);
        }
    }
}
