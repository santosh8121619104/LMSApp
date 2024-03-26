using System;
using System.Collections.Generic;

namespace LMSApp.Api.Models;

public partial class Quiz
{
    public int QuizId { get; set; }

    public int? CourseId { get; set; }

    public string? QuizName { get; set; }

    public string? Description { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual ICollection<UserProgress> UserProgresses { get; set; } = new List<UserProgress>();
}
