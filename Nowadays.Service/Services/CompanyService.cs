using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nowadays.Core.DTOs.Requests;
using Nowadays.Core.DTOs.Responses;
using Nowadays.Core.Entities;
using Nowadays.Core.Interfaces.Services;
using Nowadays.Core.Interfaces.UnitOfWorks;

namespace Nowadays.Service.Services;

public class CompanyService : ICompanyService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task CompanyAdd(CreateCompanyRequest company)
    {
        var newCompany = _mapper.Map<CreateCompanyRequest, Company>(company);

        await _unitOfWork.CompanyRepository.InsertAsync(newCompany);
        await _unitOfWork.CommitAsync();
    }

    public async Task CompanyUpdate(UpdateCompanyRequest company)
    {
        var updatedCompany = await GetById(company.Id) ?? throw new Exception("Şirket Bulunamadı!!");

        updatedCompany.Name = company.Name;

        await _unitOfWork.CompanyRepository.UpdateAsync(updatedCompany);
        await _unitOfWork.CommitAsync();
    }

    public async Task CompanyDelete(int id)
    {
        var company = await GetById(id) ?? throw new Exception("Şirket bulunamadı!!");
        if(company != null)
        {
            await _unitOfWork.CompanyRepository.Delete(company);
            await _unitOfWork.CommitAsync();
        }
    }

    public IEnumerable<GetCompanyResponse> GetAll()
    {
        var companyList = _unitOfWork.CompanyRepository.GetAll().Include(x => x.Projects).ToList();

        return _mapper.Map<List<GetCompanyResponse>>(companyList);
    }

    public async Task<Company> GetById(int id)
    {
        return await _unitOfWork.CompanyRepository.GetByIdAsync(id);
    }
}
