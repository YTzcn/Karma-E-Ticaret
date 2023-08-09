using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Business.Abstract;
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

        public void Add(Image image)
        {
            _imageDal.Add(image);
        }

        public void Delete(Image image)
        {
            _imageDal.Delete(image);
        }

        public Image GetImageById(int ImageId)
        {
            return _imageDal.Get(x => x.ImageId == ImageId);
        }

        public List<Image> GetImagesByProductId(int ProductId)
        {
            return _imageDal.GetList(x => x.ProductId == ProductId);
        }

        public void Update(Image image)
        {
            _imageDal.Update(image);
        }
    }
}
