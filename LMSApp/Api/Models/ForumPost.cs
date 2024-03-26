using System;
using System.Collections.Generic;

namespace LMSApp.Api.Models;

public partial class ForumPost
{
    public int PostId { get; set; }

    public int? ForumId { get; set; }

    public int? UserId { get; set; }

    public DateTime? PostDate { get; set; }

    public string? PostContent { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public virtual DiscussionForum? Forum { get; set; }

    public virtual User? User { get; set; }
}
