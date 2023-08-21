using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Core.DataAccess;
using Karma.Core.DataAccess.EntityFramework;
using Karma.Entities.Concrete;

namespace Karma.DataAccess.Abstract
{
    public interface ICouponDal : IEntityRepository<Coupon>
    {
    }
}
