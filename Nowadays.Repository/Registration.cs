using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nowadays.Core.Interfaces.UnitOfWorks;
using Nowadays.Repository.Context;
using Nowadays.Repository.UnitOfWorks;

namespace Nowadays.Repository;

public static class Registration
{
    //this ile IServiceCollection extension metodu olarak oluşur
    public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt =>
        opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
