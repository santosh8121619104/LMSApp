using LMSApp.Api.Models;
using LMSApp.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LMSApp.Pages
{
    public class CoursesModel : PageModel
    {
        private readonly ICourseRepository _repository;

        public CoursesModel(ICourseRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Course> CourseList { get; set; }

        public async Task OnGetAsync()
        {
            CourseList = await _repository.GetAllAsync();
        }
    }
}
