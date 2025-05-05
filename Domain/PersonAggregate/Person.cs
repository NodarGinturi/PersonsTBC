using Persons.Domain.CityAggregate;
using Persons.Domain.Common;
using Persons.Domain.PhoneNumberAggregate;

namespace Persons.Domain.PersonAggregate;

public class Person : BaseEntity
{
    public Person(string firstName, string lastName, GenderTypes gender, string personalNumber, DateOnly birthDate, string imageUrl, int cityId) 
    {
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        PersonalNumber = personalNumber;
        BirthDate = birthDate;
        ImageUrl = imageUrl;
        CityId = cityId;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Person() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public GenderTypes Gender { get; set; }
    public string PersonalNumber { get; set; }
    public DateOnly BirthDate { get; set; }
    public City City { get; set; }
    public int CityId { get; set; }
    public string ImageUrl { get; set; }
}
