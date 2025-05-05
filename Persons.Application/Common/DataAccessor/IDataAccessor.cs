using Microsoft.EntityFrameworkCore;
using Persons.Domain.CityAggregate;
using Persons.Domain.PersonAggregate;
using Persons.Domain.PhoneNumberAggregate;
using System.Collections.Generic;

namespace Persons.Application.Common.DataAccessor;

public interface IDataAccessor
{
    DbSet<Person> Persons { get; set; }
    DbSet<RelatedPerson> RelatedPersons { get; set; }
    DbSet<City> Cities { get; set; }
    DbSet<Phone> Phones { get; set; }
}
