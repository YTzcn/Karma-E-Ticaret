using Karma.Entities.Concrete;

namespace Karma.MvcUI
{
    public class OrdersListModel:Order
    {
        public string UserName { get; set; }
        public DateTime Date { get; set; } 
    }
}