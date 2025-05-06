using CSharpFunctionalExtensions;
using MediatR;
using Persons.Application.Contracts.Persistence;

namespace Persons.Application.Features.Persons.Commands.Delete;

public record DeletePersonCommand(int Id) : IRequest<Result>;

public class DeletePersonCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeletePersonCommand, Result>
{
    public async Task<Result> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await unitOfWork.PersonRepository.GetByIdAsync(request.Id, cancellationToken);

        if (person == null) return Result.Failure("Person does not exist");

        return Result.Success();
    }
}
