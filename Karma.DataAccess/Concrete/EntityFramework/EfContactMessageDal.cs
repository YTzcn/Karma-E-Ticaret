﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Core.DataAccess.EntityFramework;
using Karma.DataAccess.Abstract;
using Karma.Entities.Concrete;

namespace Karma.DataAccess.Concrete.EntityFramework
{
    public class EfContactMessageDal : EfEntityRepositoryBase<ContactMessage, KarmaContext>, IContactMessageDal
    {
    }
}
