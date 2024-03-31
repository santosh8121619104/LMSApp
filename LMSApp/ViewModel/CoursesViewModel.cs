using LMSApp.Api.Models;

namespace LMSApp.ViewModel
{
    public class CoursesViewModel
    {
        public  string ContainerId { get; internal set; }
        public string Name { get; set; }
        public PaginatedList<Course> CourseList { get; set; }
        public string sortParameter { get; internal set; }
        public string filterParameter { get; internal set; }
        public int PageSize { get; internal set; }
    }
}
