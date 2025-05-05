#nullable disable
using Persons.Domain.Common;

namespace Persons.Domain.CityAggregate;

public class City : BaseEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
}
