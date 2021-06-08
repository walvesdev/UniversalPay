using System;
using System.Collections.Generic;
using UniversalPay.Domain.Enumns;

namespace UniversalPay.Domain.Entities
{
    public class PayAccount : EntityBase
    {
        public Guid ClientId { get; set; }

        public Client Client { get; set; }

        public long Code { get; set; }

        public decimal Total { get; set; }
    }
}
