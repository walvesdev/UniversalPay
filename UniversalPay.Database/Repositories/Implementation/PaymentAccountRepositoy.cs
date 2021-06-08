using System;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Database.Repositories.Contracts
{
    public class PaymentAccountRepositoy : Repository<PaymentAccount, Guid>, IPaymentAccountRepositoy
    {
        public PaymentAccountRepositoy(UniversalPayContext ctx) : base(ctx)
        {
        }
    }
}
