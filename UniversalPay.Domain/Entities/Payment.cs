using System;
using UniversalPay.Domain.Enumns;

namespace UniversalPay.Domain.Entities
{
    public class Payment : EntityBase
    {
        public TransacitonType TransacitonType { get; set; }

        public DateTime Date { get; set; }

        public Status Status { get; set; }

        public Guid ClientId { get; set; }

        public Client Client { get; set; }

        public string TransactionData { get; set; }

        public decimal Total { get; set; }
    }
}


