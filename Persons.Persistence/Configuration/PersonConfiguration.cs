using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Persons.Domain.PersonAggregate;
using Persons.Domain.PhoneNumberAggregate;

namespace Persons.Persistence.Configuration;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasIndex(x => x.Id);
        builder.HasIndex(x => x.PersonalNumber);

        builder.Property(x => x.PersonalNumber)
            .HasMaxLength(11);

        builder.Property(x => x.FirstName)
            .HasMaxLength(50);

        builder.Property(x => x.LastName)
            .HasMaxLength(50);

        builder.HasOne(x => x.City).WithMany().OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.Phone)
            .WithOne(ph => ph.Person)
            .HasForeignKey<Phone>(ph => ph.PersonId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
