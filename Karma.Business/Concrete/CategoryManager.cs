using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Business.Abstract;
using Karma.DataAccess.Abstract;
using Karma.Entities;

namespace Karma.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return filter == null ? _categoryDal.GetList() : _categoryDal.GetList(filter);
        }

        public Category Get(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.Get(filter);
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }

        public List<Category> GetAllActive()
        {
            return _categoryDal.GetList(x => x.Active == true);
        }

        
    }
}
