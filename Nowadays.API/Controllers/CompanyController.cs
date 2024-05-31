using Microsoft.AspNetCore.Mvc;
using Nowadays.Core.DTOs.Requests;
using Nowadays.Core.Interfaces.Services;


namespace Nowadays.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpGet]
    public IActionResult GetCompanies()
    {
        var companies = _companyService.GetAll();
        return Ok(companies);
    }

    [HttpPost]
    public async Task<IActionResult> AddCompany(CreateCompanyRequest newCompany)
    {
        await _companyService.CompanyAdd(newCompany);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCompany(UpdateCompanyRequest updateCompany)
    {
        await _companyService.CompanyUpdate(updateCompany);
        return Ok(updateCompany);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        var company = await _companyService.GetById(id);
        if (company == null) return NotFound();

        await _companyService.CompanyDelete(id);
        return NoContent();
    }


}
