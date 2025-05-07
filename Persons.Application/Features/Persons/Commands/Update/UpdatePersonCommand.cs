using CSharpFunctionalExtensions;
using MediatR;
using Persons.Application.Contracts.Persistence;
using Persons.Domain.PersonAggregate;

namespace Persons.Application.Features.Persons.Commands.Update;

public record UpdatePersonCommand(
    int Id, 
    string FirstName, 
    string LastName, 
    GenderTypes Gender, 
    string PersonalNumber, 
    DateOnly BirthDate, 
    int CityId) : IRequest<Result>;

public class UpdatePersonCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdatePersonCommand, Result>
{
    public async Task<Result> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await unitOfWork.PersonRepository.GetByIdAsync(request.Id, cancellationToken);

        if (person is null) return Result.Failure("Person does not exist");

        var city = await unitOfWork.CityRepository.GetByIdAsync(request.CityId, cancellationToken);

        if (city is null) return Result.Failure("City does not exist");

        person.Update(
            request.FirstName,
            request.LastName, 
            request.Gender, 
            request.PersonalNumber,
            request.BirthDate, 
            city);

        await unitOfWork.PersonRepository.UpdateAsync(person, cancellationToken);

        return Result.Success();
    }
}
