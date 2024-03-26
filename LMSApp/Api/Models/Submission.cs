using System;
using System.Collections.Generic;

namespace LMSApp.Api.Models;

public partial class Submission
{
    public int SubmissionId { get; set; }

    public int? UserId { get; set; }

    public int? AssignmentId { get; set; }

    public DateTime? SubmissionDate { get; set; }

    public string? SubmittedFileName { get; set; }

    public string? Grade { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public virtual Assignment? Assignment { get; set; }

    public virtual User? User { get; set; }
}
