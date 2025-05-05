using Microsoft.EntityFrameworkCore;
using Persons.Domain.PersonAggregate;
using Persons.Application.Common.DataAccessor;
using Persons.Domain.CityAggregate;
using Persons.Domain.PhoneNumberAggregate;
using System.Reflection;
using Persons.Persistence.Interceptors;
using Persons.Persistence.Extensions;

namespace Persons.Persistence;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options), IDataAccessor
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<RelatedPerson> RelatedPersons { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Phone> Phones { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.SetSoftDeleteFilter();

        builder.Entity<City>().HasData(
        new City { Id = 1, Name = "Tbilisi", Created = new DateTime(2024, 01, 01, 0, 0, 0) },
        new City { Id = 2, Name = "Batumi", Created = new DateTime(2024, 01, 01, 0, 0, 0) });

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(new EntityInterceptor());

        base.OnConfiguring(optionsBuilder);
    }
}
