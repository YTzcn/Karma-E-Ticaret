using Karma.Business.Abstract;
using Karma.DataAccess.Abstract;
using Karma.Entities.Concrete;
using Karma.MvcUI;
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
                Status = 1,
                Detail = JsonConvert.SerializeObject(order.Detail),
                Total = order.Total,
                UserId = order.UserId
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
        public List<Order> GetAll(int ordersStatus)
        {
            return _orderDal.GetList(x => x.Status == ordersStatus);
        }

        public void Update(Order order)
        {
            _orderDal.Update(order);
        }
    }
}
