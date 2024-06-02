using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Core.DTOs.Requests;
using Nowadays.Core.Interfaces.Services;
using Nowadays.Service.Services;

namespace Nowadays.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService) // Dependency Injection
    {
        _projectService = projectService;
    }

    [HttpGet]
    public IActionResult GetProjects() // GET
    {
        var projects = _projectService.GetAll();
        return Ok(projects);
    }

    [HttpPost]
    public async Task<IActionResult> AddProject(CreateProjectRequest newProject) // POST
    {
        await _projectService.ProjectAdd(newProject);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProject(UpdateProjectRequest updateProject) // PUT
    {
        await _projectService.ProjectUpdate(updateProject);
        return Ok(updateProject);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProject(int id) // DELETE
    {
        var project = await _projectService.GetById(id);
        if (project == null) return NotFound();

        await _projectService.ProjectDelete(id);
        return NoContent();
    }
}
