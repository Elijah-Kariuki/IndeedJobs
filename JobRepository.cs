using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using IndeedJobs.Models;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using MySqlX.XDevAPI;
using Newtonsoft.Json.Linq;
using System.Web;
using IndeedJobs.Interfaces;


namespace IndeedJobs
{
    public class JobRepository : IJobRepository
    {
        private readonly IDbConnection _conn;
        //private readonly MySettings _mySettings;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        

        public JobRepository(IDbConnection conn, HttpClient httpClient, IConfiguration configuration1)
        {
            _conn = conn;
            //_mySettings = options.Value;
            _httpClient = httpClient;
            _configuration = configuration1;
        }

        public IEnumerable<Job> GetAllJobs()
        {
            return _conn.Query<Job>("SELECT * FROM JOBS;");
        }

        public Job GetJob(int id)
        {
            return _conn.QuerySingle<Job>("SELECT * FROM JOBS WHERE id = @id",
                               new { id = id });
        }
    }
}
