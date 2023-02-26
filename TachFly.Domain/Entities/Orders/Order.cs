using System.Security.Principal;
using TachFly.Domain.Commons;
using TachFly.Domain.Enums;

namespace TachFly.Domain.Entities.Orders
{
    public class Order : Auditable
    {
        public string Name { get; set; } = string.Empty;
        public long ClientId { get; set; }
        public long ProductId { get; set; }
        public int Count { get; set; }
        public decimal TotalSum { get; set; }
        public PaymentType PaymentType { get; set; }
        public OrderStatus Status { get; set; }
    }
}
