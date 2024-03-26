using System;
using System.Collections.Generic;

namespace LMSApp.Api.Models;

public partial class UserPreference
{
    public int PreferenceId { get; set; }

    public int? UserId { get; set; }

    public string? Theme { get; set; }

    public string? Language { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public virtual User? User { get; set; }
}
