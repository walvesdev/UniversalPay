using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversalPay.Domain.Enumns;

namespace UniversalPay.Domain.Entities
{
    public class Client : EntityBase
    {
        public string Name { get; set; }

        public Guid? AccountId { get; set; }

        public PaymentAccount Account { get; set; }

        public List<Payment> Payments { get; set; }

        public Client()
        {
            Payments = new List<Payment>();
        }

    }
}
