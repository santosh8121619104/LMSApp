using System;
using System.Collections.Generic;

namespace LMSApp.Api.Models;

public partial class Resource
{
    public int ResourceId { get; set; }

    public int? CourseId { get; set; }

    public int? ModuleId { get; set; }

    public string? ResourceName { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Module? Module { get; set; }
}
