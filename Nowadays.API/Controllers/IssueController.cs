using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Core.Interfaces.Services;

namespace Nowadays.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IssueController : ControllerBase
{
    private readonly IIssueService _issueService;

    public IssueController(IIssueService issueService)
    {
        _issueService = issueService;
    }

    [HttpGet]
    public IActionResult GetIssues()
    {
        var issues = _issueService.GetAll();
        return Ok(issues);
    }
}
