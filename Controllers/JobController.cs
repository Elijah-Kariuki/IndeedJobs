using IndeedJobs.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using IndeedJobs.Models;

namespace IndeedJobs.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobRepository repo;
        private readonly IndeedJobAPIClient _indeedJobAPIClient;

        public JobController(IJobRepository repo, IndeedJobAPIClient indeedJobAPIClient)
        {
            this.repo = repo;
            _indeedJobAPIClient = indeedJobAPIClient;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index(string offset, string keyword, string location)
        {
            var jsonResult = await _indeedJobAPIClient.GetJobsAsync(keyword, location);

            // First, let's create a Job from the JSON
            List<Job> jobs = JsonConvert.DeserializeObject<List<Job>>(jsonResult);


            // Now you can continue to use the 'jobs' list as before
            var model = new JobViewModel
            {
                Results = jobs,
                // Add any other necessary data here
            };

            return View(model);
        }
        public IActionResult ViewJob(int id)
        {
            var job = repo.GetJob(id);
            return View(job);
        }
    }
}
