using MediatR;
using System;
using UniversalPay.Domain.Dtos;

namespace UniversalPay.Application.AccountUseCases.Requests
{
    public class AccountGetByIdRequest : IRequest<PaymentAccountDto>
    {
        public Guid Id { get; set; }
    }
}
