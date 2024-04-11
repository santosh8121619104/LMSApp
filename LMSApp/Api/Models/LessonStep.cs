using System;
using System.Collections.Generic;

namespace LMSApp.Api.Models;

public partial class LessonStep
{
    public int LessonId { get; set; }

    public int LessonStepId { get; set; }

    public int? CourseId { get; set; }

    public string? StepName { get; set; }

    public string? Content { get; set; }

    public TimeOnly? Runtime { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public bool IsPaid { get; set; }

    public int? ContentType { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Lesson Lesson { get; set; } = null!;
}
