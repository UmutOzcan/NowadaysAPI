namespace Nowadays.Core.DTOs.Requests;

public class CreateCompanyRequest
{
    public string Name { get; set; }
    public List<int> ProjectIds { get; set; }
}
