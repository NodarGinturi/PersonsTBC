using CSharpFunctionalExtensions;
using MediatR;
using Persons.Application.Contracts.Persistence;
using Persons.Domain.PersonAggregate;

namespace Persons.Application.Features.Persons.Queries;

public record GetPersonRelationsQuery(RelationTypes RelationType) : IRequest<Result<GetPersonRelationsResponse>>;

public record GetPersonRelationsResponse(List<PersonRelationInfo> PersonRelations);

public record PersonRelationInfo
{
    public int PersonId { get; set; }
    public string PersonName { get; set; }
    public int RelationCount { get; set; }
}

public class GetPersonRelationsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPersonRelationsQuery, Result<GetPersonRelationsResponse>>
{
    public async Task<Result<GetPersonRelationsResponse>> Handle(GetPersonRelationsQuery request, CancellationToken cancellationToken)
    {
        var persons = await unitOfWork.PersonRepository.ListAllAsync(cancellationToken);

        var filteredPersons = persons
                     .Where(person => person.RelatedPersons != null &&
                     person.RelatedPersons.Any(r => r.ConnectType == request.RelationType)).ToList();

        var personRelations = filteredPersons.Select(person => new PersonRelationInfo
        {
            PersonId = person.Id,
            PersonName = person.FirstName + ' ' + person.LastName,
            RelationCount = person.RelatedPersons.Count(r => r.ConnectType == request.RelationType)
        }).ToList();


        var response = new GetPersonRelationsResponse(personRelations);

        return Result.Success(response);
    }
}
