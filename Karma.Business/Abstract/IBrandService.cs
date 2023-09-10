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
        List<Brand> GetAll();
        Brand GetById(int Id);
        void Add(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);
        bool IsExist(Brand brand);
        int[]? GetAllId(string[] brands);
    }
}
