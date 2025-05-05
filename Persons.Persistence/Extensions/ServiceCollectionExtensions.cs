using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Persons.Application.Contracts.Persistence;
using Persons.Persistence.Repositories;
using Persons.Application.Common.DataAccessor;

namespace Persons.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
        );
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDataAccessor, ApplicationDbContext>();
        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IRelatedPersonRepository, RelatedPersonRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IPhoneRepository, PhoneRepository>();
        return services;
    }
}
