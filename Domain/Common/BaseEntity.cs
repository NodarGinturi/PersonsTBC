namespace Persons.Domain.Common;

public class BaseEntity
{
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset LastModified { get; set; }
    public bool IsDeleted { get; set; }
}
