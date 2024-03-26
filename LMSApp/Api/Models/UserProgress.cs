using System;
using System.Collections.Generic;

namespace LMSApp.Api.Models;

public partial class UserProgress
{
    public int UserProgressId { get; set; }

    public int? UserId { get; set; }

    public int? CourseId { get; set; }

    public int? ModuleId { get; set; }

    public int? LessonId { get; set; }

    public int? QuizId { get; set; }

    public int? ProgressPercentage { get; set; }

    public string? UserName { get; set; }

    public string? CourseName { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Module? Module { get; set; }

    public virtual Quiz? Quiz { get; set; }

    public virtual User? User { get; set; }
}
