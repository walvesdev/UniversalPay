using System;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Database.Repositories.Contracts
{
    public class PaymentRepositoy : Repository<Payment, Guid>, IPaymentRepositoy
    {
        public PaymentRepositoy(UniversalPayContext ctx) : base(ctx)
        {
        }
    }
}
