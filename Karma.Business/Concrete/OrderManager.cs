using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Karma.Business.Abstract;
using Karma.DataAccess.Abstract;
using Karma.Entities.Concrete;
using Karma.MvcUI;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;

namespace Karma.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public void Add(NewOrderModel order)
        {
            Order order1 = new Order()
            {
                Active = true,
                Detail = JsonConvert.SerializeObject(order.Detail),
                Total = order.Total,
                UserId = order.UserId//new IdentityUser()
                //{
                //    Id = order.UserId
                //}
            };
            _orderDal.Add(order1);
        }

        public Order Get(int id)
        {
            return _orderDal.Get(x => x.OrderId == id);
        }

        public List<Order> GetAll()
        {
            return _orderDal.GetList();
        }
    }
}
