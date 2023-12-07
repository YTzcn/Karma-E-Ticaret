using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Entities.Concrete;

namespace Karma.Business.Abstract
{
    public interface IOrderService
    {
        void Add(Order order);
        List<Order> GetAll();
        Order Get(int id);
    }
}
