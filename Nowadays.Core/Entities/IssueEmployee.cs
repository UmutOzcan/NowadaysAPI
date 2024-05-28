﻿
namespace Nowadays.Core.Entities;

public class IssueEmployee : IEntity
{
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public int IssueId { get; set; }
    public Issue Issue { get; set; }
}
