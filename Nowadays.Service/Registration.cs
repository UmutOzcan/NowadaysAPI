using Microsoft.Extensions.DependencyInjection;
using Nowadays.Core.Interfaces.Services;
using Nowadays.Service.Mapping;
using Nowadays.Service.Services;

namespace Nowadays.Service;

public static class Registration
{
    public static void AddService(this IServiceCollection services)
    {
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IIssueService, IssueService>();
        services.AddScoped<IReportService, ReportService>();

        services.AddAutoMapper(typeof(MappingProfile));
    }
}
