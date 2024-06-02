using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Core.Interfaces.Services;

namespace Nowadays.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService) // Dependency Injection
    {
        _reportService = reportService;
    }

    [HttpGet]
    public IActionResult GetReport() // GET
    {
        var reports = _reportService.GenerateReport();
        return Ok(reports);
    }
}
