using Karma.Business.Abstract;
using Karma.DataAccess.Abstract;
using Karma.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Concrete
{
    public class ShowcaseProductsManager : IShowcaseProductsService
    {
        private readonly IShowcaseProductsDal _showcaseProductsDal;
        public ShowcaseProductsManager(IShowcaseProductsDal showcaseProductsDal)
        {
            _showcaseProductsDal = showcaseProductsDal;
        }
        public void Add(ShowcaseProducts showcaseProducts)
        {
            _showcaseProductsDal.Add(showcaseProducts);
        }

        public void Delete(ShowcaseProducts product)
        {
            _showcaseProductsDal.Delete(product);
        }

        public ShowcaseProducts Get(int id)
        {
            return _showcaseProductsDal.GetWithProduct(x => x.Id == id);
        }

        public List<ShowcaseProducts> GetList()
        {
            return _showcaseProductsDal.GetAllList();
        }

        public void Update(ShowcaseProducts showcaseProducts)
        {
            _showcaseProductsDal.Update(showcaseProducts);
        }
    }
}
