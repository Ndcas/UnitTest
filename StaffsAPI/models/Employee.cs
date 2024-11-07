using System;
using System.Collections.Generic;

namespace StaffsAPI.models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public int GenderId { get; set; }

    public int DepartmentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime StartingDate { get; set; }

    public virtual Department? Department { get; set; } = null!;

    public virtual Gender? Gender { get; set; } = null!;
}
