using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persons.Application.Features.RelatedPersons.Commands.Create;
using Persons.Application.Features.RelatedPersons.Commands.Delete;

namespace Persons.Api.Controllers
{
    public class RelatedPersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RelatedPersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(ApiEndpoints.Persons.RelatedCreate)]
        public async Task<ActionResult<CreateRelatedPersonResponse>> Create(CreateRelatedPersonCommand createRelatedPersonCommand)
        {
            var response = await _mediator.Send(createRelatedPersonCommand);

            if (response.IsFailure) return BadRequest(response.Error);

            return Ok(response.Value);
        }

        [HttpDelete(ApiEndpoints.Persons.RelatedDelete)]
        public async Task<ActionResult<Result>> Delete(DeleteRelatedPersonCommand createRelatedPersonCommand)
        {
            var response = await _mediator.Send(createRelatedPersonCommand);

            if (response.IsFailure) return BadRequest(response.Error);

            return Ok();
        }

    }
}
