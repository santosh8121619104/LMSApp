using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LMSApp.Api.Models;

public partial class LmsContext : DbContext
{
    public LmsContext()
    {
    }

    public LmsContext(DbContextOptions<LmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Announcement> Announcements { get; set; }

    public virtual DbSet<Assessment> Assessments { get; set; }

    public virtual DbSet<Assignment> Assignments { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<DiscussionForum> DiscussionForums { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<ForumPost> ForumPosts { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<Submission> Submissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserActivityLog> UserActivityLogs { get; set; }

    public virtual DbSet<UserPreference> UserPreferences { get; set; }

    public virtual DbSet<UserProgress> UserProgresses { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-MIB0F8M3;Database=Lms;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Announcement>(entity =>
        {
            entity.HasKey(e => e.AnnouncementId).HasName("PK__Announce__9DE445545CCBA3E5");

            entity.ToTable("Announcement");

            entity.Property(e => e.AnnouncementId).HasColumnName("AnnouncementID");
            entity.Property(e => e.AnnouncementText).HasColumnType("text");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.NotificationType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Course).WithMany(p => p.Announcements)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Announcem__Cours__1DB06A4F");

            entity.HasOne(d => d.User).WithMany(p => p.Announcements)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Announcem__UserI__1EA48E88");
        });

        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasKey(e => e.AssessmentId).HasName("PK__Assessme__3D2BF83E1CFE8C04");

            entity.ToTable("Assessment");

            entity.Property(e => e.AssessmentId).HasColumnName("AssessmentID");
            entity.Property(e => e.AssessmentName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.AssessmentType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

            entity.HasOne(d => d.Course).WithMany(p => p.Assessments)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Assessmen__Cours__30C33EC3");

            entity.HasOne(d => d.Module).WithMany(p => p.Assessments)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__Assessmen__Modul__31B762FC");
        });

        modelBuilder.Entity<Assignment>(entity =>
        {
            entity.HasKey(e => e.AssignmentId).HasName("PK__Assignme__32499E57F27E7EEC");

            entity.ToTable("Assignment");

            entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");
            entity.Property(e => e.AssignmentName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

            entity.HasOne(d => d.Course).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Assignmen__Cours__7D439ABD");

            entity.HasOne(d => d.Module).WithMany(p => p.Assignments)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__Assignmen__Modul__7E37BEF6");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D71878AC8F4D7");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.InstructorId).HasColumnName("InstructorID");
            entity.Property(e => e.InstructorName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Courses)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK__Course__Instruct__3F466844");
        });

        modelBuilder.Entity<DiscussionForum>(entity =>
        {
            entity.HasKey(e => e.ForumId).HasName("PK__Discussi__E210AC4F792C10AD");

            entity.ToTable("DiscussionForum");

            entity.Property(e => e.ForumId).HasColumnName("ForumID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ForumName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModeratorId).HasColumnName("ModeratorID");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");

            entity.HasOne(d => d.Course).WithMany(p => p.DiscussionForums)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Discussio__Cours__0A9D95DB");

            entity.HasOne(d => d.Moderator).WithMany(p => p.DiscussionForums)
                .HasForeignKey(d => d.ModeratorId)
                .HasConstraintName("FK__Discussio__Moder__0B91BA14");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId).HasName("PK__Enrollme__7F6877FB6A9BD524");

            entity.ToTable("Enrollment");

            entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Enrollmen__Cours__44FF419A");

            entity.HasOne(d => d.User).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Enrollmen__UserI__440B1D61");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF6934A39D8");

            entity.ToTable("Feedback");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FeedbackText).IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Course).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Feedback__Course__6442E2C9");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Feedback__UserID__65370702");
        });

        modelBuilder.Entity<ForumPost>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__ForumPos__AA12603815D3DB81");

            entity.ToTable("ForumPost");

            entity.Property(e => e.PostId).HasColumnName("PostID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ForumId).HasColumnName("ForumID");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.PostContent).HasColumnType("text");
            entity.Property(e => e.PostDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Forum).WithMany(p => p.ForumPosts)
                .HasForeignKey(d => d.ForumId)
                .HasConstraintName("FK__ForumPost__Forum__114A936A");

            entity.HasOne(d => d.User).WithMany(p => p.ForumPosts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ForumPost__UserI__123EB7A3");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradeId).HasName("PK__Grade__54F87A3769AA87FD");

            entity.ToTable("Grade");

            entity.Property(e => e.GradeId).HasColumnName("GradeID");
            entity.Property(e => e.AssessmentId).HasColumnName("AssessmentID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Grade1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Grade");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.SubmissionDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Assessment).WithMany(p => p.Grades)
                .HasForeignKey(d => d.AssessmentId)
                .HasConstraintName("FK__Grade__Assessmen__3864608B");

            entity.HasOne(d => d.User).WithMany(p => p.Grades)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Grade__UserID__37703C52");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.LessonId).HasName("PK__Lesson__B084ACB04D4D10C9");

            entity.ToTable("Lesson");

            entity.Property(e => e.LessonId).HasColumnName("LessonID");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LessonName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Lesson__CourseID__4D5F7D71");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.ModuleId).HasName("PK__Module__2B7477870971D4C0");

            entity.ToTable("Module");

            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.ModuleName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Modules)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Module__CourseID__66603565");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__Question__0DC06F8C69A51E48");

            entity.ToTable("Question");

            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            entity.Property(e => e.CorrectAnswer)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.Options).HasColumnType("text");
            entity.Property(e => e.QuestionText).HasColumnType("text");
            entity.Property(e => e.QuizId).HasColumnName("QuizID");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuizId)
                .HasConstraintName("FK__Question__QuizID__778AC167");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.QuizId).HasName("PK__Quiz__8B42AE6EF9B1A206");

            entity.ToTable("Quiz");

            entity.Property(e => e.QuizId).HasColumnName("QuizID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.QuizName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Quiz__CourseID__71D1E811");
        });

        modelBuilder.Entity<Resource>(entity =>
        {
            entity.HasKey(e => e.ResourceId).HasName("PK__Resource__4ED1814F2B313C3D");

            entity.ToTable("Resource");

            entity.Property(e => e.ResourceId).HasColumnName("ResourceID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.ResourceName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.Resources)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__Resource__Course__245D67DE");

            entity.HasOne(d => d.Module).WithMany(p => p.Resources)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__Resource__Module__25518C17");
        });

        modelBuilder.Entity<Submission>(entity =>
        {
            entity.HasKey(e => e.SubmissionId).HasName("PK__Submissi__449EE105E7F5E9AA");

            entity.ToTable("Submission");

            entity.Property(e => e.SubmissionId).HasColumnName("SubmissionID");
            entity.Property(e => e.AssignmentId).HasColumnName("AssignmentID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Grade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.SubmissionDate).HasColumnType("datetime");
            entity.Property(e => e.SubmittedFileName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Assignment).WithMany(p => p.Submissions)
                .HasForeignKey(d => d.AssignmentId)
                .HasConstraintName("FK__Submissio__Assig__04E4BC85");

            entity.HasOne(d => d.User).WithMany(p => p.Submissions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Submissio__UserI__03F0984C");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCACCFD56CE4");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserActivityLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__UserActi__5E5499A85E897BAE");

            entity.ToTable("UserActivityLog");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.ActivityDate).HasColumnType("datetime");
            entity.Property(e => e.ActivityDetails).HasColumnType("text");
            entity.Property(e => e.ActivityType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.UserActivityLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserActiv__UserI__2B0A656D");
        });

        modelBuilder.Entity<UserPreference>(entity =>
        {
            entity.HasKey(e => e.PreferenceId).HasName("PK__UserPref__E228490FA5BFCA85");

            entity.Property(e => e.PreferenceId).HasColumnName("PreferenceID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Language)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.Theme)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.UserPreferences)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserPrefe__UserI__3E1D39E1");
        });

        modelBuilder.Entity<UserProgress>(entity =>
        {
            entity.HasKey(e => e.UserProgressId).HasName("PK__UserProg__DD2907C60DB6D93E");

            entity.ToTable("UserProgress");

            entity.Property(e => e.UserProgressId).HasColumnName("UserProgressID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CourseName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LessonId).HasColumnName("LessonID");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.ModuleId).HasColumnName("ModuleID");
            entity.Property(e => e.QuizId).HasColumnName("QuizID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Course).WithMany(p => p.UserProgresses)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK__UserProgr__Cours__44CA3770");

            entity.HasOne(d => d.Module).WithMany(p => p.UserProgresses)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__UserProgr__Modul__45BE5BA9");

            entity.HasOne(d => d.Quiz).WithMany(p => p.UserProgresses)
                .HasForeignKey(d => d.QuizId)
                .HasConstraintName("FK__UserProgr__QuizI__47A6A41B");

            entity.HasOne(d => d.User).WithMany(p => p.UserProgresses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserProgr__UserI__43D61337");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A55F36E6A56");

            entity.ToTable("UserRole");

            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            entity.Property(e => e.CreateDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(sysdatetimeoffset())");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserRole__UserID__17F790F9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
