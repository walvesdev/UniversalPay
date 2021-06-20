using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Filters;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net.Mime;
using System.Threading.Tasks;
using UniversalPay.Application.AccountUseCases.Requests;
using UniversalPay.Domain.Entities;

namespace UniversalPay.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiConventionType(typeof(DefaultApiConventions))]
    public class AccountController : ControllerBase
    {

        private readonly IMediator Mediator;

        public AccountController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpGet]
        //[ApiConventionMethod(typeof(DefaultApiConventions),
        //             nameof(DefaultApiConventions.Get))]

        [ApiConventionMethod(typeof(DefaultApiConventions),
                     nameof(AppConventions.Get))]

        //[Authorize(Policy = "admin")]
        public async Task<ActionResult> Get()
        {
            var response = await Mediator.Send(new AccountGetRequest());
            if (response == null)
            {
                return NotFound("Account not found!");
            }

            return Ok(response);
        }

        [HttpGet("{id}.{format?}")]
        //[Authorize(Policy = "admin")]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(Guid id)
        {
            var response = await Mediator.Send(new AccountGetByIdRequest { Id = id });
            if (response == null)
            {
                //return NotFound("conta nao encontrada!");
            }

            return Ok(response);
        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response> 
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates a new product",
            Description = "Requires admin privileges",
            OperationId = "CreateProduct"
            )]
        [SwaggerResponse(201, "The product was created", typeof(PaymentAccount))]
        [SwaggerResponse(400, "The product data is invalid")]
        //[Authorize(Policy = "admin")]
        //[Consumes("application/xml")]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> Post([FromBody] PaymentAccount value)
        {

            var response = await Mediator.Send(new AccountCreateRequest { PaymentAccount = value });
            if (response == null)
            {
                throw new HttpResponseException() { Status = 400, Value = "Erro ao adicionar" };
                //return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
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

    public static class AppConventions
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status100Continue)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void Get()
        {
        }
    }

    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        [HttpGet]
        public IActionResult ErrorLocalDevelopment(
            [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.EnvironmentName != "Development")
            {
                throw new HttpResponseException( );
            }

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem(
                detail: context.Error.StackTrace,
                title: context.Error.Message);
        }

    }

    public class HttpResponseException : Exception
    {
        public int Status { get; set; } = 500;

        public object Value { get; set; }
    }


    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException exception)
            {
                context.Result = new ObjectResult(exception.Value)
                {
                    StatusCode = exception.Status,
                };
                context.ExceptionHandled = true;
            }
        }
    }

}
