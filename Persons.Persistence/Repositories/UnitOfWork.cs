using Microsoft.Extensions.DependencyInjection;
using Persons.Application.Contracts.Persistence;

namespace Persons.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IServiceProvider _serviceProvider;

    public UnitOfWork(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public IPersonRepository PersonRepository => _serviceProvider.GetService<IPersonRepository>();

    public IRelatedPersonRepository RelatedPersonRepository => _serviceProvider.GetService<IRelatedPersonRepository>();

    public ICityRepository CityRepository => _serviceProvider.GetService<ICityRepository>();
    public IPhoneRepository PhoneRepository => _serviceProvider.GetService<IPhoneRepository>();
}
