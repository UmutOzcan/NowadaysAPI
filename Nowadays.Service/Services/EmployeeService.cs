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
    private readonly INationalIdentityVerificationService _nationalIdentityVerificationService;

    public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper, INationalIdentityVerificationService nationalIdentityVerificationService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _nationalIdentityVerificationService = nationalIdentityVerificationService;
    }
    public async Task EmployeeAdd(CreateEmployeeRequest employee)
    {
        if (!await _nationalIdentityVerificationService.VerifyIdentityAsync(employee.NationalIdentity, employee.FirstName, employee.LastName, employee.DateOfBirth))
        {
            throw new Exception("Invalid TC Kimlik No");
        }

        var newEmployee = _mapper.Map<CreateEmployeeRequest, Employee>(employee);

        await _unitOfWork.EmployeeRepository.InsertAsync(newEmployee);
        await _unitOfWork.CommitAsync();
    }

    public async Task EmployeeDelete(int id)
    {
        var employee = await GetById(id) ?? throw new Exception("Çalışan bulunamadı!!");
        if (employee != null)
        {
            await _unitOfWork.EmployeeRepository.Delete(employee);
            await _unitOfWork.CommitAsync();
        }
    }

    public async Task EmployeeUpdate(UpdateEmployeeRequest employee)
    {
        var updatedEmployee = await GetById(employee.Id) ?? throw new Exception("Çalışan Bulunamadı!!");

        updatedEmployee.FirstName = employee.FirstName;
        updatedEmployee.LastName = employee.LastName;
        updatedEmployee.NationalIdentity = employee.NationalIdentity;
        updatedEmployee.DateOfBirth = employee.DateOfBirth;
        updatedEmployee.ProjectId = employee.ProjectId;

        await _unitOfWork.EmployeeRepository.UpdateAsync(updatedEmployee);
        await _unitOfWork.CommitAsync();
    }

    public IEnumerable<GetEmployeeResponse> GetAll()
    {
        var employeeList = _unitOfWork.EmployeeRepository.GetAll().Include(x => x.Project).ToList();

        return _mapper.Map<List<GetEmployeeResponse>>(employeeList);
    }

    public async Task<Employee> GetById(int id)
    {
        return await _unitOfWork.EmployeeRepository.GetByIdAsync(id);
    }
}
