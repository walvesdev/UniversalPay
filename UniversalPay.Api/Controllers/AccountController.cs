using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UniversalPay.Application.AccountUseCases.Requests;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IMediator Mediator;

        public AccountController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Get()
        {
            var response = await Mediator.Send(new AccountGetRequest());
            if (response == null)
            {
                return BadRequest("Account not found!");
            }

            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await Mediator.Send(new AccountGetByIdRequest { Id = id });
            if (response == null)
            {
                return BadRequest("Account not found!");
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PaymentAccount value)
        {
            var response = await Mediator.Send(new AccountCreateRequest {  PaymentAccount = value });
            if (response == null)
            {
                return BadRequest("Erro ao inserir dados!");
            }

            return Created(nameof(Post), response);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
