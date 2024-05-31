using AutoMapper;
using Nowadays.Core.DTOs.Requests;
using Nowadays.Core.DTOs.Responses;
using Nowadays.Core.Entities;
namespace Nowadays.Service.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Company
        CreateMap<Company, GetCompanyResponse>()
            .ForMember(dest => dest.ProjectNames, opt => opt.MapFrom(src => src.Projects != null && src.Projects.Count != 0
                ? string.Join(", ", src.Projects.Select(p => p.Name))
                : " - "));
        CreateMap<CreateCompanyRequest, Company>();
        CreateMap<UpdateCompanyRequest, Company>();

        // Employee 
        CreateMap<Employee, GetEmployeeResponse>()
            .ForMember(dest => dest.ProjectNames, opt => opt.MapFrom(src => src.Projects != null && src.Projects.Count != 0
                ? string.Join(", ", src.Projects.Select(p => p.Name))
                : " - "))
            .ForMember(dest => dest.IssueNames, opt => opt.MapFrom(src => src.Issues != null && src.Issues.Count != 0
                ? string.Join(", ", src.Issues.Select(p => p.Name))
                : " - ")); ;
        CreateMap<CreateEmployeeRequest, Employee>()
            .ForMember(dest => dest.Issues, opt => opt.Ignore())
            .ForMember(dest => dest.Projects, opt => opt.Ignore());
        CreateMap<UpdateEmployeeRequest, Employee>()
            .ForMember(dest => dest.Issues, opt => opt.Ignore())
            .ForMember(dest => dest.Projects, opt => opt.Ignore());

    }
}
