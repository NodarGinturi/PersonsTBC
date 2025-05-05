using Persons.Domain.PersonAggregate;

namespace Persons.Application.Contracts.Persistence;

public interface IPersonRepository : IAsyncRepository<Person>
{
    Task<bool> IsPersonalNumberUnique(string pid);
}
