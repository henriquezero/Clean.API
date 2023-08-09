using Clean.Application.Commands.Customer;
using Clean.Application.Queries.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(FindCustomerResponse[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromServices] IMediator mediator)
        {

            var response = await mediator.Send(new FindCustomerRequest());
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FindCustomerResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] Guid id, 
                                                 [FromServices] IMediator mediator)
        {
                var response = await mediator.Send(new FindCustomerByIdRequest(id));
                return Ok(response);
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(CreateCustomerResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromServices] IMediator mediator,
                                    [FromBody] CreateCustomerRequest command)
        {
            var response = await mediator.Send(command);
            return CreatedAtAction(nameof(Create), response);
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(typeof(CreateCustomerResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromServices] IMediator mediator,
                                    [FromBody] UpdateCustomerRequest command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Route("")]
        [ProducesResponseType(typeof(CreateCustomerResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromServices] IMediator mediator,
                                    [FromBody] DeleteCustomerRequest command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
