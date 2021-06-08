using MediatR;
using System.Collections.Generic;
using UniversalPay.Domain.Dtos;

namespace UniversalPay.Application.AccountUseCases.Requests
{
    public class AccountGetRequest : IRequest<List<PaymentAccountDto>>
    {
        public List<PaymentAccountDto> PaymentAccounts { get; set; }
    }
}
