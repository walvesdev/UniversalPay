using System;

namespace UniversalPay.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Guid RoleId { get; set; }

        public virtual Role Role { get; set; }

        public string Token { get; set; }
    }
}
