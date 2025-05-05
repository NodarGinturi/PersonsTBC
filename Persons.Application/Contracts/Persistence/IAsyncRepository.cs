namespace Persons.Application.Contracts.Persistence;

public interface IAsyncRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<T>> ListAllAsync(int? id, CancellationToken cancellationToken);
    Task<List<T>> ListAllAsync(CancellationToken cancellationToken);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity, CancellationToken cancellationToken);
    Task DeleteAsync(T entity, CancellationToken cancellationToken);
}
