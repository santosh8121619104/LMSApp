using System;
using System.Collections.Generic;

namespace LMSApp.Api.Models;

public partial class Grade
{
    public int GradeId { get; set; }

    public int? UserId { get; set; }

    public int? AssessmentId { get; set; }

    public string? Grade1 { get; set; }

    public DateTime? SubmissionDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public virtual Assessment? Assessment { get; set; }

    public virtual User? User { get; set; }
}
