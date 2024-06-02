using Nowadays.Core.DTOs.Requests;
using Nowadays.Core.DTOs.Responses;
using Nowadays.Core.Entities;

namespace Nowadays.Core.Interfaces.Services;
public interface IIssueService
{
    IEnumerable<GetIssueResponse> GetAll();
    Task IssueeAdd(CreateIssueRequest issue);
    Task<Issue> GetById(int id);
    Task IssueUpdate(UpdateIssueRequest issue);
    Task IssueDelete(int id);
}
