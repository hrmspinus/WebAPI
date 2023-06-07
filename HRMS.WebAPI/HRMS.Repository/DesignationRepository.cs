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
    public class DesignationRepository : IDesignationRepository
    {
        public readonly IConfiguration _configuration;
        public DesignationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<Designation>> GetDesignations()
        {
            var query = "SELECT * FROM Designation";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var designations = await connection.QueryAsync<Designation>(query);
                connection.Close();
                return designations.ToList();
            }

        }
    }
}
