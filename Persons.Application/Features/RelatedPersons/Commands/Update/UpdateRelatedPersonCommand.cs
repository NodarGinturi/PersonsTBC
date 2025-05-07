using CSharpFunctionalExtensions;
using MediatR;
using Persons.Application.Contracts.Persistence;
using Persons.Application.Features.Persons.Commands.Update;
using Persons.Domain.PersonAggregate;

namespace Persons.Application.Features.RelatedPersons.Commands.Update;

public record UpdateRelatedPersonCommand(
    int Id,
    string FirstName,
    string LastName,
    GenderTypes Gender,
    string PersonalNumber,
    DateOnly BirthDate,
    int CityId) : IRequest<Result>;

public class UpdateRelatedPersonCommandHandler(IUnitOfWork unitOfWork, IMediator mediator) : IRequestHandler<UpdateRelatedPersonCommand, Result>
{
    public async Task<Result> Handle(UpdateRelatedPersonCommand request, CancellationToken cancellationToken)
    {
        var relatedPerson = await unitOfWork.RelatedPersonRepository.GetByIdAsync(request.Id, cancellationToken);

        if (relatedPerson == null) return Result.Failure("Related person does not exist");

        var response = await mediator.Send(new UpdatePersonCommand(
            relatedPerson.PersonId,
            request.FirstName,
            request.LastName,
            request.Gender,
            request.PersonalNumber,
            request.BirthDate,
            request.CityId
            ));

        if (response.IsFailure) return Result.Failure(response.Error);

        return Result.Success();
    }
}
