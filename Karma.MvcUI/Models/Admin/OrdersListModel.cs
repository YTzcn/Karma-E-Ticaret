using Karma.Entities.Concrete;

namespace Karma.MvcUI
{
    public class OrdersListModel
    {
        public int OrderId { get; set; }
        public decimal Total { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public byte Status { get; set; }
        public string Detail { get; set; }
    }
}