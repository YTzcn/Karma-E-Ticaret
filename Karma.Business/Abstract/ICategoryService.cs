using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Entities;

namespace Karma.Business.Abstract
{
    public interface ICategoryService
    {
        Category Get(Expression<Func<Category, bool>> filter = null);
        List<Category> GetAll(Expression<Func<Category, bool>> filter = null);
        void Add(Category category);
        void Delete(Category category);
        void Update(Category category);
        List<Category> GetAllActive();
    }
}
