using System;
using System.Collections.Generic;

namespace LMSApp.Api.Models;

public partial class Module
{
    public int ModuleId { get; set; }

    public int? CourseId { get; set; }

    public string? ModuleName { get; set; }

    public string? Description { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public virtual ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();

    public virtual ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

    public virtual Course? Course { get; set; }

    public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();

    public virtual ICollection<UserProgress> UserProgresses { get; set; } = new List<UserProgress>();
}
