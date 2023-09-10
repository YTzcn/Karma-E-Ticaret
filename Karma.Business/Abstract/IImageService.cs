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
        List<Image> GetAll();
        Image GetById(int Id);
        void Add(Image image);
        void Delete(Image image);
        void Update(Image image);
    }
}
