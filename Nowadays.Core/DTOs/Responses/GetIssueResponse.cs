using Nowadays.Core.Entities;

namespace Nowadays.Core.DTOs.Responses;

public class GetIssueResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ProjectId { get; set; }
    public int? EmployeeId { get; set; }
}
