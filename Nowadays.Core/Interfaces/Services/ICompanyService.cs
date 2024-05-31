
using Nowadays.Core.DTOs.Requests;
using Nowadays.Core.DTOs.Responses;
using Nowadays.Core.Entities;

namespace Nowadays.Core.Interfaces.Services;

public interface ICompanyService
{
    IEnumerable<GetCompanyResponse> GetAll();
    Task CompanyAdd(CreateCompanyRequest company);
    Task<Company> GetById(int id);
    Task CompanyUpdate(UpdateCompanyRequest company);
    Task CompanyDelete(int id);

}
