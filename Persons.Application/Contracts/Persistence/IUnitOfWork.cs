namespace Persons.Application.Contracts.Persistence;

public interface IUnitOfWork
{
    IPersonRepository PersonRepository { get; }
    IRelatedPersonRepository RelatedPersonRepository { get; }
    ICityRepository CityRepository { get; }
    IPhoneRepository PhoneRepository { get; }
}
