using System;
using System.ComponentModel.DataAnnotations;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Domain.Dtos
{
    public class PaymentAccount2 : EntityBase
    {
        public Guid ClientId { get; set; }

        public Client Client { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        public long Code { get; set; }

        public decimal Total { get; set; }
    }
}
