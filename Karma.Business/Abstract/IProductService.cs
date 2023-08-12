﻿using System;
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
        Product GetById(int ProductId);
        List<Product> GetByCategoryId(int CategoryId);
        List<Product> GetAll(Expression<Func<Product, bool>> filter = null);
        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
        List<Product> GetByFilter(int? categoryId, int[]? brandId, string[]? color, string? lowerValue, string? upperValue);
    }
}
