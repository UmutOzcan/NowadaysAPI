namespace Nowadays.Core.DTOs.Requests;

public class UpdateIssueRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int ProjectId { get; set; }
    public int? EmployeeId { get; set; }
}
