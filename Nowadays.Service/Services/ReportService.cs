using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nowadays.Core.DTOs.Responses;
using Nowadays.Core.Interfaces.Services;
using Nowadays.Core.Interfaces.UnitOfWorks;

namespace Nowadays.Service.Services;

public class ReportService : IReportService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ReportService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public IEnumerable<GetIssueResponse> GenerateReport()
    {
        var issueList = _unitOfWork.IssueRepository.GetAll().Include(x => x.Project).Include(y => y.Employee).ToList();

        return _mapper.Map<List<GetIssueResponse>>(issueList);
    }
}
