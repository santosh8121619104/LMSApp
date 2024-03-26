using System;
using System.Collections.Generic;

namespace LMSApp.Api.Models;

public partial class DiscussionForum
{
    public int ForumId { get; set; }

    public int? CourseId { get; set; }

    public string? ForumName { get; set; }

    public string? Description { get; set; }

    public int? ModeratorId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset? CreateDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTimeOffset? ModifiedDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual ICollection<ForumPost> ForumPosts { get; set; } = new List<ForumPost>();

    public virtual User? Moderator { get; set; }
}
