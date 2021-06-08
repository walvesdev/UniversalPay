using System;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Database.Repositories.Contracts
{
    public class PaymentAccountRepositoy : Repository<PaymentAccount, Guid>
    {
        public PaymentAccountRepositoy(UniversalPayContext ctx) : base(ctx)
        {
        }
    }
}
