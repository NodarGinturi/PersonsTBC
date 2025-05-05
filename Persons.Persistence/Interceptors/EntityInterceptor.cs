using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persons.Domain.Common;

namespace Persons.Persistence.Interceptors;

public class EntityInterceptor() : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext? context)
    {
        if (context == null)
            return;

        foreach (var entry in context.ChangeTracker.Entries<BaseEntity>())
        {
            var now = DateTime.UtcNow;

            if (entry.State is EntityState.Added or EntityState.Modified || entry.HasChangedOwnedEntities())
            {
                entry.Entity.LastModified = now;
            }

            if (entry.State == EntityState.Deleted)
            {
                entry.Entity.IsDeleted = true;
                entry.Entity.LastModified = now;
                entry.State = EntityState.Modified;

                foreach (var ownedEntry in entry.GetDeletedOwnedEntities())
                {
                    ownedEntry.State = EntityState.Unchanged;
                }
            }
        }
    }
}


public static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry != null &&
            r.TargetEntry.Metadata.IsOwned() &&
            r.TargetEntry.State is EntityState.Added or EntityState.Modified);

    public static IEnumerable<EntityEntry> GetDeletedOwnedEntities(this EntityEntry entry) =>
        entry.References.Where(r =>
                r.TargetEntry != null &&
                r.TargetEntry.Metadata.IsOwned() &&
                r.TargetEntry.State is EntityState.Deleted)
            .Select(x => x.TargetEntry!);
}