using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nowadays.Core.DTOs.Requests;
using Nowadays.Core.DTOs.Responses;
using Nowadays.Core.Entities;
using Nowadays.Core.Interfaces.Services;
using Nowadays.Core.Interfaces.UnitOfWorks;

namespace Nowadays.Service.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task EmployeeAdd(CreateEmployeeRequest employee)
    {
        var newEmployee = _mapper.Map<CreateEmployeeRequest, Employee>(employee);

        await _unitOfWork.EmployeeRepository.InsertAsync(newEmployee);
        await _unitOfWork.CommitAsync();
    }

    public async Task EmployeeDelete(int id)
    {
        var employee = await GetById(id) ?? throw new Exception("Şirket bulunamadı!!");
        if (employee != null)
        {
            await _unitOfWork.EmployeeRepository.Delete(employee);
            await _unitOfWork.CommitAsync();
        }
    }

    public async Task EmployeeUpdate(UpdateEmployeeRequest employee)
    {
        var updatedEmployee = await GetById(employee.Id) ?? throw new Exception("Şirket Bulunamadı!!");

        updatedEmployee.FirstName = employee.FirstName;
        updatedEmployee.LastName = employee.LastName;
        updatedEmployee.NationalIdentity = employee.NationalIdentity;
        updatedEmployee.DateOfBirth = employee.DateOfBirth;

        await _unitOfWork.EmployeeRepository.UpdateAsync(updatedEmployee);
        await _unitOfWork.CommitAsync();
    }

    public IEnumerable<GetEmployeeResponse> GetAll()
    {
        var employeeList = _unitOfWork.EmployeeRepository.GetAll().Include(x => x.Projects).Include(y => y.Issues).ToList();

        return _mapper.Map<List<GetEmployeeResponse>>(employeeList);
    }

    public async Task<Employee> GetById(int id)
    {
        return await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
    }
}
