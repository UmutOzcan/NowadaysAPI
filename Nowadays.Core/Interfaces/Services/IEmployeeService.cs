using Nowadays.Core.DTOs.Requests;
using Nowadays.Core.DTOs.Responses;
using Nowadays.Core.Entities;

namespace Nowadays.Core.Interfaces.Services;
public interface IEmployeeService
{
    IEnumerable<GetEmployeeResponse> GetAll();
    Task EmployeeAdd(CreateEmployeeRequest employee);
    Task<Employee> GetById(int id);
    Task EmployeeUpdate(UpdateEmployeeRequest employyee);
    Task EmployeeDelete(int id);
}
