using LMSApp.Api.Models;
using LMSApp.Api.Repositories.Interfaces;
using LMSApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LMSApp.Components
{
    public class AuthorViewComponent : ViewComponent
    {
        private readonly IuserRepository _repository;

        public AuthorViewComponent(IuserRepository repository)
        {
            _repository = repository;
        }


        public async Task<IViewComponentResult> InvokeAsync(int userId)
        {
            AuthorViewModel authorView = new AuthorViewModel();

            User user = await _repository.GetByIdAsync(userId);

            authorView.Name = $"{user.FirstName} {user.LastName}";
            authorView.Description = $"{user.FirstName} {user.LastName} is a software developer at LearnD*ash. With more than 20 years o*f software development experience, he has gained a passion for Agile software development";
            List<AuthorCourses> courses = new List<AuthorCourses>();
            foreach (var item in user.Courses)
            {
                AuthorCourses authorCourses = new AuthorCourses()
                {
                    CourseDescription = item.Description,
                    CourseName = item.CourseName,
                    RunTime = Sum(item.LessonSteps.ToList()),
                    AverageRating = CalculateAverageRating(item.Feedbacks.ToList())
                };
                courses.Add(authorCourses);
            }
            authorView.authorCourses = courses;
            return View("Default", authorView);

        }

        private double CalculateAverageRating(List<Feedback> feedbacks)
        {
            int totalRating = feedbacks.Sum(f => f.RatingScore);

            // Calculate the average rating
            double averageRating = (double)totalRating / feedbacks.Count;
           return Math.Round(averageRating, 1);

        }
        private string Sum(List<LessonStep> lessonSteps)
        {
            long totalMilliseconds = lessonSteps.Sum(step => (step.Runtime ?? new TimeOnly(0, 0, 0)).ToTimeSpan().Ticks / TimeSpan.TicksPerMillisecond);
            TimeSpan totalSpan = TimeSpan.FromMilliseconds(totalMilliseconds);
            TimeOnly totalRuntime = new TimeOnly(totalSpan.Hours, totalSpan.Minutes, totalSpan.Seconds);
            int totalHours = (int)totalSpan.TotalHours;
            int totalMinutes = totalSpan.Minutes;

            return $"{totalHours}h {totalMinutes}m";
        }
    }
}
