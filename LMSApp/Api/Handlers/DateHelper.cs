namespace LMSApp.Api.Handlers
{
 
        public class DateHelper
        {
            public static string CalculateDateText(DateTime givenDateTime)
            {
                // Current datetime
                DateTime currentDateTime = DateTime.Now;

                // Calculate the time difference
                TimeSpan timeDifference = currentDateTime - givenDateTime;

                // Format the result based on the elapsed time
                string result;

                switch (timeDifference.Days)
                {
                    case 0:
                        result = "today";
                        break;
                    case 1:
                        result = "1 day ago";
                        break;
                    default:
                        if (timeDifference.Days < 31)
                        {
                            result = $"{timeDifference.Days} days ago";
                        }
                        else if (timeDifference.Days < 61)
                        {
                            result = "1 month ago";
                        }
                        else if (timeDifference.Days < 365)
                        {
                            int months = (int)Math.Floor(timeDifference.Days / 30.0);
                            result = $"{months} months ago";
                        }
                        else if (timeDifference.Days < 730)
                        {
                            result = "1 year ago";
                        }
                        else
                        {
                            int years = (int)Math.Floor(timeDifference.Days / 365.0);
                            result = $"{years} years ago";
                        }
                        break;
                }

                return result;
            }
        }
}
