using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Business.Abstract;
using Karma.Business.ValidationRules.FluentValidation;
using Karma.Core.Aspects.Postsharp;
using Karma.Core.Aspects.Postsharp.ValidationAspects;
using Karma.Core.CrossCuttingConcerns.Validation.FluentValidation;
using Karma.DataAccess.Abstract;
using Karma.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace Karma.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        [FluentValidationAspect(typeof(CategoryValidator))]
        public void Add(Category category)
        {
            ValidatorTool.FluentValidate(new CategoryValidator(), category);
            _categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public List<Category> GetList(Expression<Func<Category, bool>> filter = null)
        {
            return filter == null ? _categoryDal.GetList() : _categoryDal.GetList(filter);
        }

        public Category Get(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.Get(filter);
        }
        [FluentValidationAspect(typeof(CategoryValidator))]
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
