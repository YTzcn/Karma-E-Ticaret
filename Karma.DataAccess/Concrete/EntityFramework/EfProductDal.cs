using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Core.DataAccess.EntityFramework;
using Karma.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Karma.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, KarmaContext>, IProductDal
    {
        public List<Product> GetDetailsList(Expression<Func<Product, bool>> filter = null)
        {
            using (var context = new KarmaContext())
            {
                var products = filter == null ? context.Products.Include(i => i.Images).Include(s => s.Spesifications).ToList() : context.Products.Include(c => c.Images).Where(filter).ToList();
                return products;
            }
        }
        public Product GetDetails(Expression<Func<Product, bool>> filter = null)
        {
            using (var context = new KarmaContext())
            {
                var product = filter == null ? context.Products.Include(i => i.Images).Include(s => s.Spesifications).FirstOrDefault() : context.Products.Include(c => c.Images).Where(filter).FirstOrDefault();
                return product;
            }
        }

        bool IProductDal.IsExsit(Product product)
        {
            using (var context = new KarmaContext())
            {
                bool exist = context.Products.Where(x => x.ProductName == product.ProductName) != null ? true : false;
                return exist;
            }


        }
    }
}
