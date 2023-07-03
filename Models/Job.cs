namespace IndeedJobs.Models
{
    public class Job
    {
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string JobLocation { get; set; }
        public string Salary { get; set; }
        public DateTime Date { get; set; }
        public string JobUrl { get; set; }
        public bool UrgentlyHiring { get; set; }
        public bool MultipleHiring { get; set; }
        public float CompanyRating { get; set; }
        public int CompanyReviews { get; set; }
        public string CompanyReviewLink { get; set; }
        public string CompanyLogoUrl { get; set; }
        public int PageNumber { get; set; }
    }
}
