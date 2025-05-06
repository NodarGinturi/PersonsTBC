using CSharpFunctionalExtensions;
using MediatR;
using Persons.Application.Contracts.Persistence;

namespace Persons.Application.Features.Persons.Queries;

public record GetPersonsQuery() : IRequest<Result>;

public class GetPersonsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPersonsQuery, Result>
{
    public async Task<Result> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
    {
        var persons = await unitOfWork.PersonRepository.ListAllAsync(cancellationToken);

        return Result.Success();
    }
}