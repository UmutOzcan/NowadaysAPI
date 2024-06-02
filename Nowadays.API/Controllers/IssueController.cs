using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Core.DTOs.Requests;
using Nowadays.Core.Interfaces.Services;
using Nowadays.Service.Services;

namespace Nowadays.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IssueController : ControllerBase
{
    private readonly IIssueService _issueService;

    public IssueController(IIssueService issueService) // Dependency Injection
    {
        _issueService = issueService;
    }

    [HttpGet]
    public IActionResult GetIssues() // GET
    {
        var issues = _issueService.GetAll();
        return Ok(issues);
    }

    [HttpPost]
    public async Task<IActionResult> AddIssue(CreateIssueRequest newIssue) // POST
    {
        await _issueService.IssueeAdd(newIssue);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateIssue(UpdateIssueRequest updateIssue) // PUT
    {
        await _issueService.IssueUpdate(updateIssue);
        return Ok(updateIssue);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteIssue(int id) // DELETE
    {
        var issue = await _issueService.GetById(id);
        if (issue == null) return NotFound();

        await _issueService.IssueDelete(id);
        return NoContent();
    }
}
