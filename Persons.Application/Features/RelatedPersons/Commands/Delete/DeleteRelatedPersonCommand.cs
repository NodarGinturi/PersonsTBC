using CSharpFunctionalExtensions;
using MediatR;
using Persons.Application.Contracts.Persistence;

namespace Persons.Application.Features.RelatedPersons.Commands.Delete;

public record DeleteRelatedPersonCommand(int Id) : IRequest<Result>;

public class DeleteRelatedPersonCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteRelatedPersonCommand, Result>
{
    public async Task<Result> Handle(DeleteRelatedPersonCommand request, CancellationToken cancellationToken)
    {
        var relatedPerson = await unitOfWork.RelatedPersonRepository.GetByIdAsync(request.Id, cancellationToken);

        if (relatedPerson == null) return Result.Failure("related person does not exist");

        await unitOfWork.RelatedPersonRepository.DeleteAsync(relatedPerson, cancellationToken);

        return Result.Success();
    }
}
