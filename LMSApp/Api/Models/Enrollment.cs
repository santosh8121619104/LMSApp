using System;
using System.Collections.Generic;

namespace LMSApp.Api.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int? UserId { get; set; }

    public int? CourseId { get; set; }

    public DateTime? EnrollmentDate { get; set; }

    public string? UserName { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual User? User { get; set; }
}
