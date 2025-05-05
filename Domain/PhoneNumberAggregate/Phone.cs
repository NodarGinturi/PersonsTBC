#nullable disable

using Persons.Domain.Common;
using Persons.Domain.PersonAggregate;

namespace Persons.Domain.PhoneNumberAggregate;

public class Phone : BaseEntity
{
    public Phone(string phoneNumber, PhoneType type, int personId)
    {
        PhoneNumber = phoneNumber;
        Type = type;
        PersonId = personId;
    }

    public int Id { get; set; }
    public PhoneType Type { get; set; }
    public string PhoneNumber { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
}
