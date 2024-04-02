using LMSApp.Api.Models;

namespace LMSApp.ViewModel
{
    public class FeedBackViewModel
    {
       public List<Feedback> feedbacks = new List<Feedback>();
       public Dictionary<int, double> ratingPercentages = new Dictionary<int, double>();

        public double averageRating { get; internal set; }
    }
}
