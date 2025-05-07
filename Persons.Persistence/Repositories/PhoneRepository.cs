using Microsoft.EntityFrameworkCore;
using Persons.Application.Contracts.Persistence;
using Persons.Domain.PhoneNumberAggregate;

namespace Persons.Persistence.Repositories;

public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
{
    public PhoneRepository(ApplicationDbContext applicationDb) : base(applicationDb)
    {

    }

    public async Task<Phone> GetByPersonId(int personId, CancellationToken cancellationToken = default) =>
        await _dbContext.Phones.FirstOrDefaultAsync(x => x.PersonId == personId, cancellationToken);
}
