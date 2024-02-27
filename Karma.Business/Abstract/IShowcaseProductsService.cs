using Karma.DataAccess.Abstract;
using Karma.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Abstract
{
    public interface IShowcaseProductsService
    {
        void Add(ShowcaseProducts showcaseProduct);
        void Update(ShowcaseProducts showcaseProduct);
        void Delete(ShowcaseProducts product);
        ShowcaseProducts Get(int id);
        List<ShowcaseProducts> GetList();
    }
}
