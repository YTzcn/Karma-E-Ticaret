using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Entities.Concrete;

namespace Karma.Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetList(Expression<Func<Brand, bool>> filter = null);
        Brand Get(Expression<Func<Brand, bool>> filter = null);
        void Add(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);
        int[]? GetAllId(Expression<Func<Brand, bool>> filter = null);
    }
}
