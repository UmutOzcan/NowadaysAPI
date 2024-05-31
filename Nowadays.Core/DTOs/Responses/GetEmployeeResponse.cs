namespace Nowadays.Core.DTOs.Responses;

public class GetEmployeeResponse
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public long NationalIdentity { get; set; }
    public int DateOfBirth { get; set; }

    public string ProjectNames { get; set; } = string.Empty;
    public string IssueNames {  get; set; } = string.Empty;
}
