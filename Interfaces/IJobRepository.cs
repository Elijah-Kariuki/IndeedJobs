using System;
using System.Collections.Generic;
using IndeedJobs.Models;

namespace IndeedJobs.Interfaces
{
    public interface IJobRepository
    {
        public IEnumerable<Job> GetAllJobs();
        public Job GetJob(int id);
        
    }

}
