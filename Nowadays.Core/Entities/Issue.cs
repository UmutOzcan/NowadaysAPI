namespace Nowadays.Core.Entities;

public class Issue : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; } // OneToMany
    public ICollection<IssueEmployee> IssueEmployees { get; set; } // ManyToMany
}
