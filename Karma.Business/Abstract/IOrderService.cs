using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karma.Entities.Concrete;
using Karma.MvcUI;

namespace Karma.Business.Abstract
{
    public interface IOrderService
    {
        void Add(NewOrderModel order);
        List<Order> GetAll();
        List<Order> GetAll(int ordersStatus);
        Order Get(int id);
        void Update(Order order);
    }
}
