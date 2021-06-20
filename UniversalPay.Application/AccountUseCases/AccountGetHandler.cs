using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UniversalPay.Application.AccountUseCases.Requests;
using UniversalPay.Database;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Application.AccountUseCases
{
    public class AccountGetHandler : IRequestHandler<AccountGetRequest, List<PaymentAccount>>
    {
        public IRepository<PaymentAccount, Guid> PaymentAccountRepositoy { get; set; }

        private IMapper Mapper { get; set;}

        public AccountGetHandler(IRepository<PaymentAccount, Guid> paymentAccountRepositoy, IMapper mapper)
        {
            PaymentAccountRepositoy = paymentAccountRepositoy;
            Mapper = mapper;
        }

        public async Task<List<PaymentAccount>> Handle(AccountGetRequest request, CancellationToken cancellationToken)
        {
            var list = await PaymentAccountRepositoy.GetAllAsync();
            var map = Mapper.Map<List<PaymentAccount>>(list);
            return map;

        }
    }
}
