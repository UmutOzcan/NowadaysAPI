namespace Nowadays.Core.DTOs.Requests;

public class CreateEmployeeRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public long NationalIdentity { get; set; }
    public int DateOfBirth { get; set; }

    public int ProjectId { get; set; }
}
