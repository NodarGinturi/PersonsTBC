using CSharpFunctionalExtensions;
using MediatR;
using Persons.Application.Contracts.Persistence;
using Persons.Application.Features.Persons.Commands.Create;
using Persons.Domain.PersonAggregate;
using Persons.Domain.PhoneNumberAggregate;

namespace Persons.Application.Features.RelatedPersons.Commands.Create;

public record CreateRelatedPersonCommand(
    int PersonId,
    RelationTypes RelationType,
    string FirstName,
    string LastName,
    GenderTypes Gender,
    string PersonalNumber,
    DateOnly BirthDate,
    int CityId,
    string ImageUrl,
    string Phone,
    PhoneType PhoneType) : IRequest<Result<CreateRelatedPersonResponse>>;

public record CreateRelatedPersonResponse(int Id);

public class CreateRelatedPersonCommandHandler(IUnitOfWork unitOfWork, IMediator mediator) : IRequestHandler<CreateRelatedPersonCommand, Result<CreateRelatedPersonResponse>>
{
    public async Task<Result<CreateRelatedPersonResponse>> Handle(CreateRelatedPersonCommand request, CancellationToken cancellationToken)
    {
        var response = await mediator.Send(new CreatePersonCommand(
            request.FirstName,
            request.LastName,
            request.Gender,
            request.PersonalNumber,
            request.BirthDate,
            request.CityId,
            request.ImageUrl,
            request.Phone,
            request.PhoneType
        ), cancellationToken);

        if (response.IsFailure)
        {
            return Result.Failure<CreateRelatedPersonResponse>(response.Error);
        }

        var relatedPerson = new RelatedPerson(request.RelationType, request.PersonId, response.Value.Id);

        await unitOfWork.RelatedPersonRepository.AddAsync(relatedPerson, cancellationToken);

        return Result.Success(new CreateRelatedPersonResponse(relatedPerson.Id));
    }
}
