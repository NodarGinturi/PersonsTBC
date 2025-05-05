namespace Persons.Domain.Common;

public class PaginatedResult<T>(IEnumerable<T> data, int totalCount, int pageNumber, int pageSize)
{
    public IEnumerable<T> Data { get; set; } = data;

    public PaginationInfo Pagination { get; } = new(pageNumber, pageSize, totalCount,
        (int)Math.Ceiling((double)totalCount / pageSize));
}

public record PaginationInfo(int PageNumber, int PageSize, int TotalCount, int TotalPages);