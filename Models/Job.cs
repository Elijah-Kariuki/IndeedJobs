﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndeedJobs.Models
{
    public class Job
    {
        public Job()
        {
        }
        [Key]
        public int Position { get; set; }
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
        public bool NextPage { get; set; }
        public int PageNumber { get; set; }
        public string Salary { get; set; }
        public string UrgentlyHiring { get; set; }

    }
}
