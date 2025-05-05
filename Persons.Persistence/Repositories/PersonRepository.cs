using Persons.Application.Contracts.Persistence;
using Persons.Domain.PersonAggregate;

namespace Persons.Persistence.Repositories;

public class PersonRepository : BaseRepository<Person>, IPersonRepository
{
    public PersonRepository(ApplicationDbContext applicationDb) : base(applicationDb)
    {
    }

    public Task<bool> IsPersonalNumberUnique(string personalNumber)
    {
        var match = _dbContext.Persons.Any(x => x.PersonalNumber == personalNumber);
        return Task.FromResult(match);
    }
}
