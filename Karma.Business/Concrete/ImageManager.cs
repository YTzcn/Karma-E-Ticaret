using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Business.Abstract;
using Karma.Business.ValidationRules.FluentValidation;
using Karma.Core.Aspects.Postsharp.CacheAspects;
using Karma.Core.Aspects.Postsharp.ExceptionsAspects;
using Karma.Core.Aspects.Postsharp.ValidationAspects;
using Karma.Core.CrossCuttingConcerns.Caching.Microsoft;
using Karma.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Karma.Core.CrossCuttingConcerns.Validation.FluentValidation;
using Karma.DataAccess.Abstract;
using Karma.Entities;

namespace Karma.Business.Concrete
{
    public class ImageManager : IImageService
    {
        private readonly IImageDal _imageDal;
        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [FluentValidationAspect(typeof(ImageValidator))]
        public void Add(Image image)
        {
            if (_imageDal.GetList(x => x.Products.ProductId == image.ProductId && x.IsMain == true).Count == 0)
            {
                image.IsMain = true;
            }
            ValidatorTool.FluentValidate(new ImageValidator(), image);
            _imageDal.Add(image);
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [FluentValidationAspect(typeof(ImageValidator))]
        public void Delete(Image image)
        {
            _imageDal.Delete(image);
        }
        [CacheAspect(typeof(MemoryCacheManager), 60)]
        public Image GetById(int Id)
        {
            return _imageDal.Get(x => x.ImageId == Id);
        }
        [CacheAspect(typeof(MemoryCacheManager), 60)]
        public List<Image> GetAll()
        {
            return _imageDal.GetList();
        }
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [FluentValidationAspect(typeof(ImageValidator))]
        public void Update(Image image)
        {
            _imageDal.Update(image);
        }
    }
}
