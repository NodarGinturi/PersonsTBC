using CSharpFunctionalExtensions;
using MediatR;
using Persons.Application.Contracts.Persistence;

namespace Persons.Application.Features.Persons.Queries;

public record GetPersonQuery(int Id) : IRequest<Result<GetPersonResponse>>;

public record GetPersonResponse();

public class GetPersonQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPersonQuery, Result<GetPersonResponse>>
{
    public async Task<Result<GetPersonResponse>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        var person = await unitOfWork.PersonRepository.GetByIdAsync(request.Id, cancellationToken);
        return Result.Success(new GetPersonResponse());
    }
}