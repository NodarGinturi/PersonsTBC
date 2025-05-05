using Persons.Application.Contracts.Persistence;
using Persons.Domain.CityAggregate;

namespace Persons.Persistence.Repositories;

public class CityRepository : BaseRepository<City>, ICityRepository
{
    public CityRepository(ApplicationDbContext applicationDb) : base(applicationDb)
    {

    }
}
