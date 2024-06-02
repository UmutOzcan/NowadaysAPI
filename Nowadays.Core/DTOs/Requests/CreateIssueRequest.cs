namespace Nowadays.Core.DTOs.Requests;

public class CreateIssueRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int ProjectId { get; set; }
    public int? EmployeeId { get; set; }
}
