namespace LMSApp.ViewModel
{
    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<AuthorCourses> authorCourses{get;set;}
    }


    public class AuthorCourses {
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string RunTime { get; set; }
        public string CreatedDate { get;set; }
        public double AverageRating { get; internal set; }
    }

}
