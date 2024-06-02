using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nowadays.Core.DTOs.Requests;
using Nowadays.Core.DTOs.Responses;
using Nowadays.Core.Entities;
using Nowadays.Core.Interfaces.Services;
using Nowadays.Core.Interfaces.UnitOfWorks;

namespace Nowadays.Service.Services;

public class ProjectService : IProjectService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task ProjectAdd(CreateProjectRequest project)
    {
        var newProject = _mapper.Map<CreateProjectRequest, Project>(project);
        await _unitOfWork.ProjectRepository.InsertAsync(newProject);
        await _unitOfWork.CommitAsync();
    }

    public async Task ProjectUpdate(UpdateProjectRequest project)
    {
        var updatedProject = await GetById(project.Id) ?? throw new Exception("Proje Bulunamadı!!");
        updatedProject.Name = project.Name;
        updatedProject.CompanyId = project.CompanyId;
        await _unitOfWork.ProjectRepository.UpdateAsync(updatedProject);
        await _unitOfWork.CommitAsync();
    }

    public async Task ProjectDelete(int id)
    {
        var project = await GetById(id) ?? throw new Exception("Proje bulunamadı!!");
        if (project != null)
        {
            await _unitOfWork.ProjectRepository.Delete(project);
            await _unitOfWork.CommitAsync();
        }
    }

    public IEnumerable<GetProjectResponse> GetAll()
    {
        var projectList = _unitOfWork.ProjectRepository.GetAll().Include(x => x.Company).Include(x => x.Employees).Include(x => x.Issues).ToList();
        return _mapper.Map<List<GetProjectResponse>>(projectList);
    }

    public async Task<Project> GetById(int id)
    {
        return await _unitOfWork.ProjectRepository.GetByIdAsync(id);
    }
}
