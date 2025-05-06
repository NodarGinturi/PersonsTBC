using CSharpFunctionalExtensions;
using MediatR;
using Persons.Application.Contracts.Persistence;

namespace Persons.Application.Features.Persons.Commands.Update;

public record UpdatePersonCommand(int Id) : IRequest<Result>;

public class UpdatePersonCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdatePersonCommand, Result>
{
    public async Task<Result> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await unitOfWork.PersonRepository.GetByIdAsync(request.Id, cancellationToken);

        if (person is null) return Result.Failure("Person does not exist");

        return Result.Success();
    }
}
