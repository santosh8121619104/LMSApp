using System;
using System.Collections.Generic;

namespace LMSApp.Api.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int? UserId { get; set; }

    public int? CourseId { get; set; }

    public string? FeedbackText { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public int RatingScore { get; set; }

    public virtual Course? Course { get; set; }

    public virtual User? User { get; set; }
}
