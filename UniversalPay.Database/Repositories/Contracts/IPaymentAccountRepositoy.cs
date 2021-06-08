using System;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Database.Repositories.Contracts
{
    public interface IPaymentAccountRepositoy : IRepository<PaymentAccount, Guid>
    {

    }
}
