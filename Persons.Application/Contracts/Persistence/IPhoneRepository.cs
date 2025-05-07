using Persons.Domain.PhoneNumberAggregate;

namespace Persons.Application.Contracts.Persistence;

public interface IPhoneRepository : IAsyncRepository<Phone>
{
    Task<Phone> GetByPersonId(int personId, CancellationToken cancellationToken = default);
}
