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
    public class ApplyLeaveRepository : IApplyLeaveRepository
    {
        public readonly IConfiguration _configuration;
        public ApplyLeaveRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<ApplyLeave>> GetApplyLeaves()
        {
            var query = "SELECT * FROM ApplyLeave";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var applyleaves = await connection.QueryAsync<ApplyLeave>(query);
                connection.Close();
                return applyleaves.ToList();
            }

        }
    }
}
