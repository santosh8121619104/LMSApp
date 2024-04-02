using LMSApp.Api.Models;
using LMSApp.Api.Repositories.Interfaces;
using LMSApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LMSApp.Components
{
    public class FeedBackViewComponent : ViewComponent
    {
        private readonly ICourseRepository _repository;

        public FeedBackViewComponent(ICourseRepository repository)
        {
            _repository = repository;
        }

        public async Task<IViewComponentResult> InvokeAsync(int CourseId)
        {
            FeedBackViewModel feedBackViewModel = new FeedBackViewModel();
            feedBackViewModel.feedbacks  = GenerateFeedbacks();
            int totalRating = feedBackViewModel.feedbacks.Sum(f => f.RatingScore);

            // Calculate the average rating
            double averageRating = (double)totalRating / feedBackViewModel.feedbacks.Count;

            //// Ensure the average rating does not exceed 5
            //averageRating = Math.Min(5, averageRating);

            // Round the average rating to two decimal places
            averageRating = Math.Round(averageRating, 1);
            feedBackViewModel.averageRating = averageRating;

            #region  calculation of rating percentage
            // Count the occurrences of each rating
            Dictionary<int, int> ratingCounts = feedBackViewModel.feedbacks
                .GroupBy(f => f.RatingScore)
                .ToDictionary(g => g.Key, g => g.Count());

            // Calculate the total number of ratings
            int totalRatings = feedBackViewModel.feedbacks.Count;

            // Calculate the percentage of each rating
            Dictionary<int, double> ratingPercentages = new Dictionary<int, double>();
            foreach (var kvp in ratingCounts)
            {
                int rating = kvp.Key;
                int count = kvp.Value;
                double percentage = (double)count / totalRatings * 100;
                ratingPercentages.Add(rating, percentage);
            }

            feedBackViewModel.ratingPercentages = ratingPercentages;

            #endregion


            return View("Default", feedBackViewModel);

        }

            private List<User> users = new List<User>
                                                    {
                                                        new User { UserId = 1, FirstName = "Alice", LastName = "Johnson" },
                                                        new User { UserId = 2, FirstName = "Bob", LastName = "Smith" },
                                                        new User { UserId = 3, FirstName = "Charlie", LastName = "Brown" },
                                                        new User { UserId = 4, FirstName = "David", LastName = "Lee" },
                                                        new User { UserId = 5, FirstName = "Eva", LastName = "Garcia" },
                                                        new User { UserId = 6, FirstName = "Frank", LastName = "Taylor" },
                                                        new User { UserId = 7, FirstName = "Grace", LastName = "Miller" },
                                                        new User { UserId = 8, FirstName = "Henry", LastName = "Anderson" },
                                                        new User { UserId = 9, FirstName = "Isabel", LastName = "Martinez" },
                                                        new User { UserId = 10, FirstName = "Jack", LastName = "Wilson" },
                                                    };


            private List<string> feedbackTemplates = new List<string>
                                                    {
                                                        "The course content was comprehensive, especially the section on {0}. It covered all the essential topics.",
                                                        "I found the explanations regarding {0} to be clear and concise. It helped me grasp the concepts easily.",
                                                        "The {0} module was informative, but I would have liked more real-world examples to better understand the application.",
                                                        "The course structure was well-designed, but I felt that the {0} section could be expanded to provide more depth.",
                                                        "The instructor's teaching style was engaging, especially in the {0} lectures. I appreciated the enthusiasm.",
                                                        "I enjoyed the practical exercises in the {0} lessons. They helped reinforce the theoretical concepts.",
                                                        "The course provided valuable insights into {0}, but I would suggest adding supplementary reading materials for further exploration.",
                                                        "The {0} topic was intriguing, but I struggled to grasp some of the advanced concepts. Additional resources would be beneficial.",
                                                        "The course forum was helpful for discussing {0} related queries with fellow students and the instructor.",
                                                        "I found the self-assessment quizzes in the {0} module to be helpful in gauging my understanding of the material.",
                                                    };


            private List<string> topics = new List<string>
                                            {
                                                "object-oriented programming",
                                                "data structures",
                                                "algorithm complexity",
                                                "design patterns",
                                                "software testing"
                                            };

            public List<Feedback> GenerateFeedbacks()
            {
                List<Feedback> feedbacks = new List<Feedback>();
                Random random = new Random();

                for (int i = 1; i <= 40; i++)
                {
                    string template = feedbackTemplates[random.Next(feedbackTemplates.Count)];
                    string topic = topics[random.Next(topics.Count)];

                Feedback feedback = new Feedback
                {
                    FeedbackId = i,
                    UserId = random.Next(1, users.Count + 1), // Randomly assign a user ID
                    FeedbackText = String.Format(template, topic),
                    RatingScore = random.Next(1, 6), // Ratings between 1 and 5
                    User = users.FirstOrDefault(a => a.UserId == random.Next(1, users.Count)),
                    CreateDate = getDateTime()

                    };

                    feedbacks.Add(feedback);
                }

                return feedbacks;
            }

        private DateTime getDateTime()
        {
            DateTime startDate = new DateTime(2021, 1, 1);
            DateTime endDate = new DateTime(2023, 12, 31);

            // Generate a random number of days to add to the start date
            Random random = new Random();
            int range = (endDate - startDate).Days;
            DateTime randomDate = startDate.AddDays(random.Next(range));
            return randomDate;
        }
        
    }
}
