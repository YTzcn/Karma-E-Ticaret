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
                var products = filter == null ? context.Products.Include(i => i.Images.Where(X => X.Active == true)).Include(s => s.Spesifications).Include(x => x.Brand).Include(x => x.Category).ToList() : context.Products.Include(i => i.Images.Where(X => X.Active == true)).Include(x => x.Brand).Include(x => x.Category).Where(filter).ToList();
                return products;
            }
        }
        public Product GetDetails(Expression<Func<Product, bool>> filter = null)
        {
            using (var context = new KarmaContext())
            {
                var product = filter == null ? context.Products.Include(i => i.Images.Where(X => X.Active == true)).Include(s => s.Spesifications).Include(x => x.Brand).Include(x => x.Category).FirstOrDefault() : context.Products.Include(i => i.Images.Where(X => X.Active == true)).Include(x => x.Brand).Include(x => x.Category).Where(filter).FirstOrDefault();
                return product;
            }
        }

        public bool IsExsit(Product product)
        {
            using (var context = new KarmaContext())
            {
                bool exist = context.Products.Where(x => x.ProductName == product.ProductName) != null ? true : false;
                return exist;
            }


        }
    }
}
