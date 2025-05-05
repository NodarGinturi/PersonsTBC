using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persons.Application.Features.Persons.Commands.Create;

namespace Persons.Api.Controllers
{
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ApiEndpoints.Persons.Create)]
        public async Task<ActionResult<CreatePersonResponse>> AddPerson(CreatePersonCommand createPersonCommand)
        {
            var response = await _mediator.Send(createPersonCommand);

            if (response.IsFailure) return BadRequest(response.Error);

            return Ok(response.Value);
        }
    }
}
