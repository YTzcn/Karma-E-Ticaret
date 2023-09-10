using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Business.Abstract;
using Karma.Business.ValidationRules.FluentValidation;
using Karma.Core.Aspects.Postsharp;
using Karma.Core.Aspects.Postsharp.CacheAspects;
using Karma.Core.Aspects.Postsharp.LogAspects;
using Karma.Core.Aspects.Postsharp.ValidationAspects;
using Karma.Core.CrossCuttingConcerns.Caching.Microsoft;
using Karma.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Karma.Core.CrossCuttingConcerns.Validation.FluentValidation;
using Karma.DataAccess.Abstract;
using Karma.Entities;

namespace Karma.Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        [FluentValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]

        public void Add(Category category)
        {
            ValidatorTool.FluentValidate(new CategoryValidator(), category);
            _categoryDal.Add(category);
        }
        [FluentValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }
        [CacheAspect(typeof(MemoryCacheManager), 60)]

        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }

        public Category GetById(int Id)
        {
            return _categoryDal.Get(x => x.CategoryId == Id);
        }
        [FluentValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
        [CacheAspect(typeof(MemoryCacheManager), 60)]

        public List<Category> GetAllActive()
        {
            return _categoryDal.GetList(x => x.Active == true);
        }
        [CacheAspect(typeof(MemoryCacheManager), 60)]

        public Category GetByCategoryName(string CategoryName)
        {
            return _categoryDal.Get(x => x.CategoryName == CategoryName);
        }
    }
}
