using TachFly.Domain.Commons;

namespace TachFly.Domain.Entities.Products;

public class ProductCategory : Auditable
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
