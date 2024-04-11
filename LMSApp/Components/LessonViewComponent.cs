using LMSApp.Api.Models;
using LMSApp.Api.Repositories.Interfaces;
using LMSApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LMSApp.Components
{
    public class LessonViewComponent : ViewComponent
    {
        private readonly ICourseRepository _repository;

        public LessonViewComponent(ICourseRepository repository)
        {
            _repository = repository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int CourseId)
        {
            Course course = await _repository.GetByIdAsync(CourseId);

            return View("Default", course);
        }

    }
}
