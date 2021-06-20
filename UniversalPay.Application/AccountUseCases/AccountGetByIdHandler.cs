using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UniversalPay.Application.AccountUseCases.Requests;
using UniversalPay.Database;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Application.AccountUseCases
{
    public class AccountGetByIdHandler : IRequestHandler<AccountGetByIdRequest, PaymentAccount>
    {
        public IRepository<PaymentAccount, Guid> PaymentAccountRepositoy { get; set; }

        private IMapper Mapper { get; set; }

        public AccountGetByIdHandler(IRepository<PaymentAccount, Guid> paymentAccountRepositoy, IMapper mapper)
        {
            PaymentAccountRepositoy = paymentAccountRepositoy;
            Mapper = mapper;
        }

        public async Task<PaymentAccount> Handle(AccountGetByIdRequest request, CancellationToken cancellationToken)
        {
            return Mapper.Map<PaymentAccount>(await PaymentAccountRepositoy.GetByIdAsync(request.Id)); ;

        }
    }
}
