using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TachFly.Domain.Commons;

namespace TachFly.Domain.Entities.Orders
{
    public class OrderComment : Auditable
    {
        public string Name { get; set; } = string.Empty;
        public long ClientId { get; set; }
        public long OrderId { get; set; }
        public string Message { get; set; } = string.Empty;


    }
}
