using Persons.Application.Contracts.Persistence;
using Persons.Domain.PersonAggregate;

namespace Persons.Persistence.Repositories;

public class RelatedPersonRepository : BaseRepository<RelatedPerson>, IRelatedPersonRepository
{
    public RelatedPersonRepository(ApplicationDbContext applicationDb) : base(applicationDb)
    {

    }
}
