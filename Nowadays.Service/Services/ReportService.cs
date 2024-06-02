using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

    public async Task<string> GenerateReport()
    {
        var issues = await _unitOfWork.IssueRepository.GetAll().ToListAsync();
        return "Report generated.";
    }
}
