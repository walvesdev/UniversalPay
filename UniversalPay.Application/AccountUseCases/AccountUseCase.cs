using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversalPay.Database.Repositories.Contracts;
using UniversalPay.Domain.Dtos;

namespace UniversalPay.Application.AccountUseCases
{
    public class AccountUseCase : IRequestHandler<AccountGetRequest, List<PaymentAccountDto>>
    {
        public IPaymentAccountRepositoy PaymentAccountRepositoy { get; set; }

        private IMapper Mapper { get; set;}

        public AccountUseCase(IPaymentAccountRepositoy paymentAccountRepositoy, IMapper mapper)
        {
            PaymentAccountRepositoy = paymentAccountRepositoy;
            Mapper = mapper;
        }

        public async Task<List<PaymentAccountDto>> Handle(AccountGetRequest request, CancellationToken cancellationToken)
        {
            var list = await PaymentAccountRepositoy.GetAllAsync();
            var map = Mapper.Map<List<PaymentAccountDto>>(list);
            return map;

        }
    }
}
