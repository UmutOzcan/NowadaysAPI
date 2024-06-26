﻿namespace Nowadays.Core.Entities;

public class Issue : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int ProjectId { get; set; }
    public Project Project { get; set; }
    public int? EmployeeId { get; set; }
    public Employee Employee { get; set; }
}
