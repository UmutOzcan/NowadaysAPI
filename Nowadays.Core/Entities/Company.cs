namespace Nowadays.Core.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Project> Projects { get; set; }
}
