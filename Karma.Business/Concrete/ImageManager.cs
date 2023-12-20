using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
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

        Cloudinary cloudinary;
        private readonly IImageDal _imageDal;
        public ImageManager(IImageDal imageDal)
        {
            Account account = new Account("drwyecoiw", "952353261815348", "Hkde1Y-ngRSBjn9K7wFFN37F74o");
            cloudinary = new Cloudinary(account);
            _imageDal = imageDal;
        }

        [FluentValidationAspect(typeof(ImageValidator))]
        public void Add(Image image)
        {

            if (_imageDal.GetList(x => x.Products.ProductId == image.ProductId && x.IsMain == true).Count == 0)
            {
                image.IsMain = true;
            }
            ValidatorTool.FluentValidate(new ImageValidator(), image);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(image.Url),
            };
            var uploadResult = cloudinary.Upload(uploadParams);
            image.PublicId = uploadResult.PublicId;
            image.Active = true;
            image.Url = "";
            _imageDal.Add(image);
        }

        [FluentValidationAspect(typeof(ImageValidator))]
        public void Delete(Image image)
        {
            _imageDal.Delete(image);
        }
        [CacheAspect(typeof(MemoryCacheManager), 60)]
        public Image GetById(int Id)
        {
            return _imageDal.Get(x => x.ImageId == Id && x.Active == true);
        }
        public List<Image> GetAll()
        {
            return _imageDal.GetList(X => X.Active == true);
        }

        [FluentValidationAspect(typeof(ImageValidator))]
        public void Update(Image image)
        {
            _imageDal.Update(image);
        }

        public void DeactiveImage(int ıd)
        {
            var image = _imageDal.Get(X => X.ImageId == ıd);
            image.Active = false;
            _imageDal.Update(image);
        }
    }
}
