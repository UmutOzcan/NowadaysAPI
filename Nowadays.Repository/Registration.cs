using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nowadays.Core.Interfaces.UnitOfWorks;
using Nowadays.Repository.Context;
using Nowadays.Repository.UnitOfWorks;

namespace Nowadays.Repository;

public static class Registration // extension method for IServiceCollection to add 'Repository' services
{
    // created as IServiceCollection extension method with 'this'
    public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
        opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>(); // Scoped services are created once per client request
    }
}
