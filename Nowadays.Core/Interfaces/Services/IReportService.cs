using Nowadays.Core.DTOs.Responses;

namespace Nowadays.Core.Interfaces.Services;
public interface IReportService
{
    IEnumerable<GetIssueResponse> GenerateReport();
}
