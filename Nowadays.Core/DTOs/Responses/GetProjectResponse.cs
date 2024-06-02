using Nowadays.Core.Entities;

namespace Nowadays.Core.DTOs.Responses;

public class GetProjectResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int CompanyId { get; set; }
    public List<int> EmployeeIds { get; set; }
    public List<int> IssueIds { get; set; }
}
