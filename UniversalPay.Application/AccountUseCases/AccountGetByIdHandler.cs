using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversalPay.Application.AccountUseCases.Requests;
using UniversalPay.Database.Repositories.Contracts;
using UniversalPay.Domain.Dtos;

namespace UniversalPay.Application.AccountUseCases
{
    public class AccountGetByIdHandler : IRequestHandler<AccountGetByIdRequest, PaymentAccountDto>
    {
        public IPaymentAccountRepositoy PaymentAccountRepositoy { get; set; }

        private IMapper Mapper { get; set; }

        public AccountGetByIdHandler(IPaymentAccountRepositoy paymentAccountRepositoy, IMapper mapper)
        {
            PaymentAccountRepositoy = paymentAccountRepositoy;
            Mapper = mapper;
        }

        public async Task<PaymentAccountDto> Handle(AccountGetByIdRequest request, CancellationToken cancellationToken)
        {
            return Mapper.Map<PaymentAccountDto>(await PaymentAccountRepositoy.GetByIdAsync(request.Id)); ;

        }
    }
}
