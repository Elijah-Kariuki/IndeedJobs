using Microsoft.EntityFrameworkCore;
using IndeedJobs.Models;

namespace IndeedJobs.Data
{
    public class IndeedJobsContext : DbContext
    {
        public IndeedJobsContext(DbContextOptions<IndeedJobsContext> options)
            : base(options)
        {
        }

        // Define your entity DbSet properties here
        
        public DbSet<Job> Jobs { get; set; }
    }
}
