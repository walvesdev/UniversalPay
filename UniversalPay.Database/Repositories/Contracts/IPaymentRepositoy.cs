using System;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Database.Repositories.Contracts
{
    public interface IPaymentRepositoy : IRepository<Payment, Guid>
    {
    }
}
