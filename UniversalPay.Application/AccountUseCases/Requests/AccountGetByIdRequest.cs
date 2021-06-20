using MediatR;
using System;
using UniversalPay.Domain.Dtos;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Application.AccountUseCases.Requests
{
    public class AccountGetByIdRequest : IRequest<PaymentAccount>
    {
        public Guid Id { get; set; }
    }
}
