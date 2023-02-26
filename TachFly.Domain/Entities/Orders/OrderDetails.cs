using TachFly.Domain.Commons;

namespace TachFly.Domain.Entities.Orders
{
    public class OrderDetails : Auditable
    {
        public long  OrderId { get; set; }
        public long  ProductId { get; set; }
        public int Amoun { get; set; }
        public decimal Price { get; set; }
    }
}
