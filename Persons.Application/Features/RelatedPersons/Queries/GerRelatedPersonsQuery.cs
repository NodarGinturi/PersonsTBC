using CSharpFunctionalExtensions;
using MediatR;
using Persons.Application.Contracts.Persistence;

namespace Persons.Application.Features.RelatedPersons.Queries;

public record GerRelatedPersonsQuery() : IRequest<Result<List<GetRelatedPersonResponse>>>;

public class GerRelatedPersonsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GerRelatedPersonsQuery, Result<List<GetRelatedPersonResponse>>>
{
    public async Task<Result<List<GetRelatedPersonResponse>>> Handle(GerRelatedPersonsQuery request, CancellationToken cancellationToken)
    {
        var relatedPersons = await unitOfWork.RelatedPersonRepository.ListAllAsync(cancellationToken);

        return Result.Success(new List<GetRelatedPersonResponse>());
    }
}
