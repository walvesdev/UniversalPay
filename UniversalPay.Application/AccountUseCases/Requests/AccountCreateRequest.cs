using MediatR;
using System;
using UniversalPay.Domain.Dtos;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Application.AccountUseCases.Requests
{
    public class AccountCreateRequest : IRequest<PaymentAccount>
    {
        public PaymentAccount PaymentAccount { get; set; }
    }
}
