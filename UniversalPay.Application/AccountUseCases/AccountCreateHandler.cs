using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UniversalPay.Application.AccountUseCases.Requests;
using UniversalPay.Database.Repositories.Contracts;
using UniversalPay.Domain.Dtos;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Application.AccountUseCases
{
    public class AccountCreateHandler : IRequestHandler<AccountCreateRequest, PaymentAccountDto>
    {
        public IPaymentAccountRepositoy PaymentAccountRepositoy { get; set; }

        private IMapper Mapper { get; set; }

        public AccountCreateHandler(IPaymentAccountRepositoy paymentAccountRepositoy, IMapper mapper)
        {
            PaymentAccountRepositoy = paymentAccountRepositoy;
            Mapper = mapper;
        }

        public async Task<PaymentAccountDto> Handle(AccountCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return Mapper.Map<PaymentAccountDto>(await PaymentAccountRepositoy.InsertAsync(request.PaymentAccount));
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
