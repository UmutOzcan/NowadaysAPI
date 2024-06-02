using AutoMapper;
using Nowadays.Core.DTOs.Requests;
using Nowadays.Core.DTOs.Responses;
using Nowadays.Core.Entities;
namespace Nowadays.Service.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Company mappings
        CreateMap<CreateCompanyRequest, Company>();
        CreateMap<UpdateCompanyRequest, Company>();
        CreateMap<Company, GetCompanyResponse>()
            .ForMember(dest => dest.ProjectIds, opt => opt.MapFrom(src => src.Projects.Select(p => p.Id)));

        // Project mappings
        CreateMap<CreateProjectRequest, Project>();
        CreateMap<UpdateProjectRequest, Project>();
        CreateMap<Project, GetProjectResponse>()
            .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id))
            .ForMember(dest => dest.EmployeeIds, opt => opt.MapFrom(src => src.Employees.Select(e => e.Id)))
            .ForMember(dest => dest.IssueIds, opt => opt.MapFrom(src => src.Issues.Select(i => i.Id)));

        // Employee mappings
        CreateMap<CreateEmployeeRequest, Employee>();
        CreateMap<UpdateEmployeeRequest, Employee>();
        CreateMap<Employee, GetEmployeeResponse>()
            .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.Id));

        // Issue mappings
        CreateMap<CreateIssueRequest, Issue>();
        CreateMap<UpdateIssueRequest, Issue>();
        CreateMap<Issue, GetIssueResponse>()
            .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.Id))
            .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Employee.Id));

    }
}
