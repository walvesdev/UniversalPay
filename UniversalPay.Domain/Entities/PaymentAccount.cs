using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniversalPay.Domain.Enumns;

namespace UniversalPay.Domain.Entities
{
    public class PaymentAccount : EntityBase
    {
        [Required(ErrorMessage = "Campo obrigatorio")]
        public long Code { get; set; }

        public decimal Total { get; set; }
    }
}
