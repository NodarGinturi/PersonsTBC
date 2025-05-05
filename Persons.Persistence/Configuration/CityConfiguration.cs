using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persons.Domain.CityAggregate;

namespace Persons.Persistence.Configuration;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasIndex(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
    }
}
