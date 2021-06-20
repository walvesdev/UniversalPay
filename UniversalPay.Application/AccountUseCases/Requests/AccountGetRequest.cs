using MediatR;
using System.Collections.Generic;
using UniversalPay.Domain.Dtos;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Application.AccountUseCases.Requests
{
    public class AccountGetRequest : IRequest<List<PaymentAccount>>
    {
        public List<PaymentAccount> PaymentAccounts { get; set; }
    }
}
