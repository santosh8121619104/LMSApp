using System;
using System.Collections.Generic;

namespace LMSApp.Api.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public int? QuizId { get; set; }

    public string? QuestionText { get; set; }

    public string? Options { get; set; }

    public string? CorrectAnswer { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public virtual Quiz? Quiz { get; set; }
}
