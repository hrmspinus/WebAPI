using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class AppraisalRepository : IAppraisalRepository
    {
        public readonly IConfiguration _configuration;
        public AppraisalRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<Appraisal>> GetAppraisals()
        {
            var query = "SELECT * FROM Appraisal";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var appraisals = await connection.QueryAsync<Appraisal>(query);
                connection.Close();
                return appraisals.ToList();
            }

        }
    }
}
