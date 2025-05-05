#nullable disable
using Persons.Domain.Common;

namespace Persons.Domain.PersonAggregate;

public class RelatedPerson : BaseEntity
{
    public int Id { get; set; }
    public RelationTypes ConnectType { get; set; }
    public int RelatedPersonId { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
}
