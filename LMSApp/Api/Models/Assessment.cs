using System;
using System.Collections.Generic;

namespace LMSApp.Api.Models;

public partial class Assessment
{
    public int AssessmentId { get; set; }

    public int? CourseId { get; set; }

    public int? ModuleId { get; set; }

    public string? AssessmentName { get; set; }

    public string? AssessmentType { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Module? Module { get; set; }
}
