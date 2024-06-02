using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nowadays.Core.DTOs.Requests;
using Nowadays.Core.Interfaces.Services;

namespace Nowadays.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService) // Dependency Injection
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public IActionResult GetEmployees() // GET
    {
        var employees = _employeeService.GetAll();
        return Ok(employees);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee(CreateEmployeeRequest newEmployee) // POST
    {
        await _employeeService.EmployeeAdd(newEmployee);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEmployee(UpdateEmployeeRequest updateEmployee) // PUT
    {
        await _employeeService.EmployeeUpdate(updateEmployee);
        return Ok(updateEmployee);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteEmployee(int id) // DELETE
    {
        var employee = await _employeeService.GetById(id);
        if (employee == null) return NotFound();

        await _employeeService.EmployeeDelete(id);
        return NoContent();
    }
}
