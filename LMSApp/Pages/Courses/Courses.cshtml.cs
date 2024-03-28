using LMSApp.Api.Handlers;
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
        private const int PageSize = 4;
        public PaginatedList<Course> CourseList { get; set; }

        public async Task OnGetAsync(int? pageIndex)
        {
            IQueryable<Course> coursesIQ = await _repository.GetAllAsync();
            CourseList = await PaginatedList<Course>.CreateAsync(
           coursesIQ, pageIndex ?? 1, PageSize);
        }
    }
}
