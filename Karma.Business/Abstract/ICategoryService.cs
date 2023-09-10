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
        Category GetByCategoryName(string CategoryName);
        Category GetById(int Id);
        List<Category> GetAll();
        void Add(Category category);
        void Delete(Category category);
        void Update(Category category);
        List<Category> GetAllActive();
    }
}
