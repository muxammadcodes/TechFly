using TachFly.Domain.Commons;

namespace TachFly.Domain.Entities.Products;

public class Product : Auditable
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public long CategoryId { get; set; }

}
