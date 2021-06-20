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
    public class AccountCreateHandler : IRequestHandler<AccountCreateRequest, PaymentAccount>
    {
        public IRepository<PaymentAccount, Guid> PaymentAccountRepositoy { get; set; }

        private IMapper Mapper { get; set; }

        public AccountCreateHandler(IRepository<PaymentAccount, Guid> paymentAccountRepositoy, IMapper mapper)
        {
            PaymentAccountRepositoy = paymentAccountRepositoy;
            Mapper = mapper;
        }

        public async Task<PaymentAccount> Handle(AccountCreateRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = Mapper.Map<PaymentAccount>(await PaymentAccountRepositoy.InsertAsync(request.PaymentAccount));
                return result;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
