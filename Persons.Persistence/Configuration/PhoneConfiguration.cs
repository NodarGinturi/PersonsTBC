using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persons.Domain.PhoneNumberAggregate;

namespace Persons.Persistence.Configuration;

public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
{
    public void Configure(EntityTypeBuilder<Phone> builder)
    {
        builder.HasIndex(x => x.Id);
        builder.Property(x => x.PhoneNumber).IsRequired();
        builder.Property(x => x.Type).IsRequired();

        builder.HasOne(x => x.Person)
             .WithOne()
             .IsRequired()
             .OnDelete(DeleteBehavior.NoAction);
    }
}
