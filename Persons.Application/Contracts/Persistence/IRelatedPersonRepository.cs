using Persons.Domain.PersonAggregate;

namespace Persons.Application.Contracts.Persistence;

public interface IRelatedPersonRepository : IAsyncRepository<RelatedPerson>
{
}
