namespace Nowadays.Core.DTOs.Responses;

public class GetCompanyResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public List<int> ProjectIds { get; set; }
}
