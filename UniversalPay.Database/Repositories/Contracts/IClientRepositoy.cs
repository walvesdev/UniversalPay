using System;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Database.Repositories.Contracts
{
    public interface IClientRepositoy : IRepository<Client, Guid>
    {
    }
}
