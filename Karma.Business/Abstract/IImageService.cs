using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Karma.Entities;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Karma.Business.Abstract
{
    public interface IImageService
    {
        List<Image> GetList(Expression<Func<Image, bool>> filter = null);
        Image Get(Expression<Func<Image, bool>> filter = null);
        void Add(Image image);
        void Delete(Image image);
        void Update(Image image);
    }
}
