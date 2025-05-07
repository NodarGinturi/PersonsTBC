using CSharpFunctionalExtensions;
using MediatR;
using Persons.Application.Contracts.Persistence;
using Persons.Domain.PersonAggregate;

namespace Persons.Application.Features.Persons.Queries;

public record GetPersonQuery(int Id) : IRequest<Result<GetPersonResponse>>;

public record GetPersonResponse(int Id, string FirstName, string LastName, GenderTypes Gender, string PersonalNumber, DateOnly BirthDate, string City, string Phone, string ImageUrl);

public class GetPersonQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPersonQuery, Result<GetPersonResponse>>
{
    public async Task<Result<GetPersonResponse>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        var person = await unitOfWork.PersonRepository.GetByIdAsync(request.Id, cancellationToken);

        var city = await unitOfWork.CityRepository.GetByIdAsync(person.CityId, cancellationToken);

        var phone = await unitOfWork.PhoneRepository.GetByPersonId(person.Id, cancellationToken);

        return Result.Success(new GetPersonResponse(person.Id, person.FirstName, person.LastName, person.Gender, person.PersonalNumber, person.BirthDate, city.Name, phone.PhoneNumber, person.ImageUrl));
    }
}