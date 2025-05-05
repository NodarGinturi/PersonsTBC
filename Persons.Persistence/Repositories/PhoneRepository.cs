using Persons.Application.Contracts.Persistence;
using Persons.Domain.PhoneNumberAggregate;

namespace Persons.Persistence.Repositories;

public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
{
    public PhoneRepository(ApplicationDbContext applicationDb) : base(applicationDb)
    {

    }
}
