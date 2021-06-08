using System;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Database.Repositories.Contracts
{
    public class ClientRepositoy : Repository<Client, Guid>
    {
        public ClientRepositoy(UniversalPayContext ctx) : base(ctx)
        {
        }
    }
}
