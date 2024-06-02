namespace Nowadays.Core.DTOs.Requests;

public class UpdateProjectRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CompanyId { get; set; }
}
