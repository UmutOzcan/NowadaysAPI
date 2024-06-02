namespace Nowadays.Core.DTOs.Responses;

public class GetEmployeeResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public long NationalIdentity { get; set; }
    public int DateOfBirth { get; set; }

    public int ProjectId { get; set; }
}
