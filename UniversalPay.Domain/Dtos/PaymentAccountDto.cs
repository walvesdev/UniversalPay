using System;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Domain.Dtos
{
    public class PaymentAccountDto
    {
        public Guid ClientId { get; set; }

        public Client Client { get; set; }

        public long Code { get; set; }

        public decimal Total { get; set; }
    }
}
