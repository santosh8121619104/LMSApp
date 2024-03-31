using LMSApp.Api.Models;
using LMSApp.Api.Repositories.Interfaces;
using LMSApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LMSApp.Components
{
    public class CoursesViewComponent : ViewComponent
    {
        private readonly ICourseRepository _repository;

        public CoursesViewComponent(ICourseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync(string sortParameter, string filterParameter, int? pageIndex,string Name, int pageSize,string ContainerId)
        {
            CoursesViewModel coursesViewModel = new CoursesViewModel();
            coursesViewModel.sortParameter = sortParameter;
            coursesViewModel.filterParameter = filterParameter;
            coursesViewModel.Name = Name;
            coursesViewModel.ContainerId = ContainerId;
            IQueryable<Course> coursesQuery = await _repository.GetAllAsync();

            // Filter
            if (!string.IsNullOrEmpty(filterParameter.Trim()))
            {
                coursesQuery = coursesQuery.Where(c => c.CourseName.Contains(filterParameter));
            }

            // Sort
            switch (sortParameter)
            {
                case "Newest":
                    coursesQuery = coursesQuery.OrderByDescending(c => c.CreateDate);
                    break;
                case "Popularity":
                    // Implement popularity sorting logic (e.g., based on enrollments)
                    break;
                default:
                    coursesQuery = coursesQuery.OrderBy(c => c.CourseName);
                    break;
            }

             // Set the number of items per page

            var paginatedList = await PaginatedList<Course>.CreateAsync(coursesQuery, pageIndex ?? 1, pageSize);
            coursesViewModel.CourseList = paginatedList;
            return View(coursesViewModel);
        }
    }
}
