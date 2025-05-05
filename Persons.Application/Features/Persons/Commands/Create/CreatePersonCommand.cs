using MediatR;
using Persons.Application.Contracts.Persistence;
using Persons.Domain.PersonAggregate;
using Persons.Domain.PhoneNumberAggregate;
using CSharpFunctionalExtensions;
using System.Transactions;

namespace Persons.Application.Features.Persons.Commands.Create;

public record CreatePersonCommand(
    string FirstName,
    string LastName,
    GenderTypes Gender,
    string PersonalNumber,
    DateOnly BirthDate,
    int CityId,
    string ImageUrl,
    string Phone,
    PhoneType PhoneType
) : IRequest<Result<CreatePersonResponse>>;

public record CreatePersonResponse(int Id);

public class CreatePersonCommandHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<CreatePersonCommand, Result<CreatePersonResponse>>
{
    public async Task<Result<CreatePersonResponse>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        if (await unitOfWork.PersonRepository.IsPersonalNumberUnique(request.PersonalNumber))
        {
            return Result.Failure<CreatePersonResponse>("Personal Number already exists.");
        }

        var city = await unitOfWork.CityRepository.GetByIdAsync(request.CityId, cancellationToken);
        if (city is null)
        {
            return Result.Failure<CreatePersonResponse>("City ID does not exist.");
        }

        var person = new Person(
            request.FirstName,
            request.LastName,
            request.Gender,
            request.PersonalNumber,
            request.BirthDate,
            request.ImageUrl,
            request.CityId);

        var phone = new Phone(request.Phone, request.PhoneType, person.Id);

        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await unitOfWork.PersonRepository.AddAsync(person, cancellationToken);
            await unitOfWork.PhoneRepository.AddAsync(phone, cancellationToken);

            scope.Complete();
        }

        return Result.Success(new CreatePersonResponse(person.Id));
    }
}
