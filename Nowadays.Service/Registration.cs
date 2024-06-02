using MernisServisReference;
using Microsoft.Extensions.DependencyInjection;
using Nowadays.API.Services;
using Nowadays.Core.Interfaces.Services;
using Nowadays.Service.Mapping;
using Nowadays.Service.Services;

namespace Nowadays.Service;

public static class Registration
{
    public static void AddService(this IServiceCollection services) // extension method for IServiceCollection to add 'Service' services
    {
        // Registering KPSPublicSoapClient dependency
        services.AddScoped<KPSPublicSoapClient>(provider =>
        {
            return new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
        });

        services.AddScoped<ICompanyService, CompanyService>(); // Scoped services are created once per client request
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IIssueService, IssueService>();
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<INationalIdentityVerificationService, NationalIdentityVerificationService>();

        services.AddAutoMapper(typeof(MappingProfile)); // Mapper 
    }
}
