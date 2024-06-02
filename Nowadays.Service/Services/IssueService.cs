using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nowadays.Core.DTOs.Requests;
using Nowadays.Core.DTOs.Responses;
using Nowadays.Core.Entities;
using Nowadays.Core.Interfaces.Services;
using Nowadays.Core.Interfaces.UnitOfWorks;

namespace Nowadays.Service.Services;

public class IssueService : IIssueService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public IssueService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public IEnumerable<GetIssueResponse> GetAll()
    {
        var issueList = _unitOfWork.IssueRepository.GetAll().Include(x => x.Project).Include(y => y.Employee).ToList();

        return _mapper.Map<List<GetIssueResponse>>(issueList);
    }

    public async Task<Issue> GetById(int id)
    {
        return await _unitOfWork.IssueRepository.GetByIdAsync(id);
    }

    public async Task IssueDelete(int id)
    {
        var issue = await GetById(id) ?? throw new Exception("Görev bulunamadı!!");
        if (issue != null)
        {
            await _unitOfWork.IssueRepository.Delete(issue);
            await _unitOfWork.CommitAsync();
        }
    }

    public async Task IssueeAdd(CreateIssueRequest issue)
    {
        var newIssue = _mapper.Map<CreateIssueRequest, Issue>(issue);

        await _unitOfWork.IssueRepository.InsertAsync(newIssue);
        await _unitOfWork.CommitAsync();
    }

    public async Task IssueUpdate(UpdateIssueRequest issue)
    {
        var updatedIssue = await GetById(issue.Id) ?? throw new Exception("Görev Bulunamadı!!");

        updatedIssue.Name = issue.Name;
        updatedIssue.Description = issue.Description;
        updatedIssue.ProjectId = issue.ProjectId;
        updatedIssue.EmployeeId = issue.EmployeeId;

        await _unitOfWork.IssueRepository.UpdateAsync(updatedIssue);
        await _unitOfWork.CommitAsync();
    }
}
