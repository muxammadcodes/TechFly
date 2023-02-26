using TachFly.Domain.Commons;
using TachFly.Domain.Enums;

namespace TachFly.Domain.Entities;

public class Client : Auditable
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Role Role { get; set; } = Role.Clent;
}
