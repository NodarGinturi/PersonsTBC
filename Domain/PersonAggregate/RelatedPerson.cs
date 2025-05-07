#nullable disable
using Persons.Domain.Common;

namespace Persons.Domain.PersonAggregate;

public class RelatedPerson : BaseEntity
{
    public RelatedPerson(RelationTypes connectType, int relatedPersonId, int personId)
    {
        ConnectType = connectType;
        PersonId = personId;
        RelatedPersonId = relatedPersonId;
    }

    public int Id { get; set; }
    public RelationTypes ConnectType { get; set; }
    public int RelatedPersonId { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
}
