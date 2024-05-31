using Nowadays.Core.Entities;

namespace Nowadays.Core.DTOs.Responses;

public class GetProjectResponse
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int CompanyId { get; set; }
    public ICollection<Issue> Issues { get; set; } 
    public ICollection<Employee> Employees { get; set; } 
}
