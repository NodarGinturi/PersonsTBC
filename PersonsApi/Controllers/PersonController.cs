using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persons.Application.Features.Persons.Commands.Create;
using Persons.Application.Features.Persons.Commands.Delete;
using Persons.Application.Features.Persons.Commands.Image;
using Persons.Application.Features.Persons.Commands.Update;
using Persons.Application.Features.Persons.Queries;

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
        public async Task<ActionResult<CreatePersonResponse>> Create(CreatePersonCommand createPersonCommand)
        {
            var response = await _mediator.Send(createPersonCommand);

            if (response.IsFailure) return BadRequest(response.Error);

            return Ok(response.Value);
        }

        [HttpPut(ApiEndpoints.Persons.Update)]
        public async Task<ActionResult<CreatePersonResponse>> Update(UpdatePersonCommand updatePersonCommand)
        {
            var response = await _mediator.Send(updatePersonCommand);

            if (response.IsFailure) return BadRequest(response.Error);

            return Ok();
        }

        [HttpPost(ApiEndpoints.Persons.Image)]
        public async Task<ActionResult<Result>> Image(UploadImageCommand uploadImageCommand)
        {
            var response = await _mediator.Send(uploadImageCommand);

            if (response.IsFailure) return BadRequest(response.Error);

            return Ok();
        }

        [HttpDelete(ApiEndpoints.Persons.Delete)]
        public async Task<ActionResult<CreatePersonResponse>> Delete(DeletePersonCommand deletePersonCommand)
        {
            var response = await _mediator.Send(deletePersonCommand);

            if (response.IsFailure) return BadRequest(response.Error);

            return Ok();
        }

        [HttpGet(ApiEndpoints.Persons.Get)]
        public async Task<ActionResult<GetPersonResponse>> Get(int Id)
        {
            var response = await _mediator.Send(new GetPersonQuery(Id));

            if (response.IsFailure) return BadRequest(response.Error);

            return Ok(response.Value);
        }

        [HttpGet(ApiEndpoints.Persons.GetAll)]
        public async Task<ActionResult<Result>> GetAll()
        {
            var response = await _mediator.Send(new GetPersonsQuery());

            if (response.IsFailure) return BadRequest(response.Error);

            return Ok();
        }

        [HttpGet(ApiEndpoints.Persons.GetRelation)]
        public async Task<ActionResult<CreatePersonResponse>> GetRelation(GetPersonRelationsQuery query)
        {
            var response = await _mediator.Send(query);

            if (response.IsFailure) return BadRequest(response.Error);

            return Ok();
        }
    }
}
