using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Persons.Domain.PersonAggregate;

namespace Persons.Persistence.Configuration;

public class RelatedPersonConfiguration : IEntityTypeConfiguration<RelatedPerson>
{

    public void Configure(EntityTypeBuilder<RelatedPerson> builder)
    {
        builder.HasIndex(x => x.Id);

        builder.Property(x => x.ConnectType)
            .IsRequired();

        builder.Property(x => x.RelatedPersonId)
            .IsRequired();

        builder.Property(x => x.PersonId)
            .IsRequired();

        builder.Property(x => x.Id)
            .IsRequired();

        builder.HasOne(x => x.Person)
             .WithMany()
             .HasForeignKey(x => x.RelatedPersonId)
             .OnDelete(DeleteBehavior.NoAction);
    }
}