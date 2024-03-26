using System;
using System.Collections.Generic;

namespace LMSApp.Api.Models;

public partial class UserRole
{
    public int UserRoleId { get; set; }

    public int? UserId { get; set; }

    public string? Role { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public virtual User? User { get; set; }
}
