using MediatR;
using System.Collections.Generic;
using UniversalPay.Domain.Dtos;

namespace UniversalPay.Application.AccountUseCases
{
    public class AccountGetRequest : IRequest<List<PaymentAccountDto>>
    {
        public List<PaymentAccountDto> PaymentAccount { get; set; }
    }
}
