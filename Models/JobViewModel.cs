namespace IndeedJobs.Models
{
    public class JobViewModel
    {
        public string CompanyLogoUrl { get; set; }
        public string CompanyName { get; set; }
        public string CompanyRating { get; set; }
        public string CompanyReviewLink { get; set; }
        public int CompanyReviews { get; set; }
        public string Date { get; set; }
        public string JobLocation { get; set; }
        public string JobTitle { get; set; }
        public string JobUrl { get; set; }
        public string MultipleHiring { get; set; }
        public string Salary { get; set; }
        public string UrgentlyHiring { get; set; }
        public IEnumerable<Job> Results { get; set; }
        public string Keyword { get; set; }
        public string Location { get; set; }
    }
}
