using Microsoft.EntityFrameworkCore;
using Persons.Domain.Common;

namespace Persons.Persistence.Extensions;

public static class IQueryableExtensions
{
    public static async Task<PaginatedResult<TEntity>> ToPagingAsync<TEntity>(this IQueryable<TEntity> query,
    int? pageNumber,
    int? pageSize, CancellationToken cancellationToken = default) where TEntity : class
    {
        var finalPageNumber = pageNumber ?? 1;
        var finalPageSize = pageSize ?? 20;

        var (data, totalCount) = await GetDataWithCount(query, finalPageSize, finalPageNumber, cancellationToken);

        return new PaginatedResult<TEntity>(data, totalCount, finalPageNumber, finalPageSize);
    }

    public static async Task<PaginatedResult<TResponse>> ToPagingAsync<TEntity, TResponse>(
        this IQueryable<TEntity> query,
        int? pageNumber,
        int? pageSize,
        Func<TEntity, TResponse> mapper, CancellationToken cancellationToken = default)
        where TEntity : class
    {
        var finalPageNumber = pageNumber ?? 1;
        var finalPageSize = pageSize ?? 20;

        var (data, totalCount) = await GetDataWithCount(query, finalPageSize, finalPageNumber, cancellationToken);

        return new PaginatedResult<TResponse>(data.Select(mapper), totalCount, finalPageNumber, finalPageSize);
    }

    private static async Task<(List<TEntity> Data, int Count)> GetDataWithCount<TEntity>(
        IQueryable<TEntity> query,
        int pageSize, int pageNumber,
        CancellationToken cancellationToken = default) where TEntity : class
    {
        var totalCount = await query.CountAsync(cancellationToken);
        var data = await query.Skip(((pageNumber - 1) * pageSize)!).Take(pageSize!)
            .ToListAsync(cancellationToken);

        return (data, totalCount);
    }
}
