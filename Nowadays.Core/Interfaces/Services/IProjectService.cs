using Nowadays.Core.DTOs.Requests;
using Nowadays.Core.DTOs.Responses;
using Nowadays.Core.Entities;

namespace Nowadays.Core.Interfaces.Services;
public interface IProjectService
{
    IEnumerable<GetProjectResponse> GetAll();
    Task ProjectAdd(CreateProjectRequest project);
    Task<Project> GetById(int id);
    Task ProjectUpdate(UpdateProjectRequest project);
    Task ProjectDelete(int id);
}
