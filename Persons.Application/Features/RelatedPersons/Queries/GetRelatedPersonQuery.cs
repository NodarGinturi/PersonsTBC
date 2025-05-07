using CSharpFunctionalExtensions;
using MediatR;
using Persons.Application.Contracts.Persistence;
using Persons.Domain.PersonAggregate;

namespace Persons.Application.Features.RelatedPersons.Queries;

public record GetRelatedPersonQuery(int Id) : IRequest<Result<GetRelatedPersonResponse>>;

public record GetRelatedPersonResponse(int Id, int PersonId, RelationTypes RelationTypes, int RelatedPersonId);

public class GetRelatedPersonQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetRelatedPersonQuery, Result<GetRelatedPersonResponse>>
{
    public async Task<Result<GetRelatedPersonResponse>> Handle(GetRelatedPersonQuery request, CancellationToken cancellationToken)
    {
        var relatedPerson = await unitOfWork.RelatedPersonRepository.GetByIdAsync(request.Id, cancellationToken);

        if (relatedPerson == null) return Result.Failure<GetRelatedPersonResponse>("related person does not exist");

        return Result.Success(new GetRelatedPersonResponse(relatedPerson.Id, relatedPerson.PersonId, relatedPerson.ConnectType, relatedPerson.RelatedPersonId));
    }
}
