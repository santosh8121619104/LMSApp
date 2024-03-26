using LMSApp.Api.Models;
using LMSApp.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LMSApp.Pages.Courses
{
    public class CourseModel : PageModel
    {
        private readonly ICourseRepository _repository;

        public CourseModel(ICourseRepository repository)
        {
            _repository = repository;
        }

        public Course Course { get; set; }

        public async Task OnGetAsync(int Id)
        {
            Course = await _repository.GetByIdAsync(Id);
        }
    }
}
