using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TachFly.Domain.Commons;
using TachFly.Domain.Enums;

namespace TachFly.Domain.Entities
{
    public class SuperAdmin : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public Role Position { get; set; } = Role.SuperAdmin;

    }
}
