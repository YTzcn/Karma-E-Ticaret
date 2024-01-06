using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Karma.Core.DataAccess.EntityFramework;
using Karma.DataAccess.Abstract;
using Karma.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Karma.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, KarmaContext>, IOrderDal
    {
        //public List<Order> GetDetailsList(Expression<Func<Product, bool>> filter = null)
        //{

        //    using (KarmaContext context = new KarmaContext())
        //    {
        //        return context.Orders.Include(x => x.User).ToList();
        //    }
        //}
    }
}
