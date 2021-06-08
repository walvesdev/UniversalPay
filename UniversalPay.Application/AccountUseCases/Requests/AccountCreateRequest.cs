using MediatR;
using System;
using UniversalPay.Domain.Dtos;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Application.AccountUseCases.Requests
{
    public class AccountCreateRequest : IRequest<PaymentAccountDto>
    {
        public PaymentAccount PaymentAccount { get; set; }
    }
}
