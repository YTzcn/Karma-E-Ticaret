using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Entities;

namespace Karma.Business.Abstract
{
    public interface IImageService
    {
        List<Image> GetImagesByProductId(int ProductId);
        Image GetImageById(int ImageId);
        void Add(Image image);
        void Delete(Image image);
        void Update(Image image);
    }
}
