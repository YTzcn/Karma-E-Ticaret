using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Core.DataAccess;
using Karma.Entities;

namespace Karma.DataAccess.Abstract
{
    public interface IImageDal : IEntityRepository<Image>
    {
    }
}
