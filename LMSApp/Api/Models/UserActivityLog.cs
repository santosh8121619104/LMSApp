using System;
using System.Collections.Generic;

namespace LMSApp.Api.Models;

public partial class UserActivityLog
{
    public int LogId { get; set; }

    public int? UserId { get; set; }

    public DateTime? ActivityDate { get; set; }

    public string? ActivityType { get; set; }

    public string? ActivityDetails { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public virtual User? User { get; set; }
}
