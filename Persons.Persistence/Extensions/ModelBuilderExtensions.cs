using Microsoft.EntityFrameworkCore;
using Persons.Domain.Common;
using System.Reflection;

namespace Persons.Persistence.Extensions;

public static class ModelBuilderExtensions
{
    public static void SetSoftDeleteFilter(this ModelBuilder modelBuilder)
    {
        foreach (var type in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(type.ClrType) && type.BaseType == null)
                modelBuilder.SetSoftDeleteFilter(type.ClrType);
        }
    }

    private static void SetSoftDeleteFilter(this ModelBuilder modelBuilder, Type entityType)
    {
        SetSoftDeleteFilterMethod.MakeGenericMethod(entityType)
            .Invoke(null, [modelBuilder]);
    }

    static readonly MethodInfo SetSoftDeleteFilterMethod = typeof(ModelBuilderExtensions)
        .GetMethods(BindingFlags.Public | BindingFlags.Static)
        .Single(t => t.IsGenericMethod && t.Name == "SetSoftDeleteFilter");

    public static void SetSoftDeleteFilter<TEntity>(this ModelBuilder modelBuilder)
        where TEntity : BaseEntity
    {
        modelBuilder.Entity<TEntity>().HasQueryFilter(x => !x.IsDeleted);
    }
}