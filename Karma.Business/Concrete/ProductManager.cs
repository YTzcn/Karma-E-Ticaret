using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Product> GetByCategoryId(int CategoryId)
        {
            return _productDal.GetAllProd(x => x.CategoryId == CategoryId);
        }

        public Product GetById(int ProductId)
        {
            return _productDal.Get(x => x.ProductId == ProductId);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAllProd();
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }

        public List<Product> GetByFilter(int[]? brandId, string[]? color, string? lowerValue, string? upperValue)
        {
            var products = _productDal.GetAllProd();
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
            return products;
        }
    }
}
