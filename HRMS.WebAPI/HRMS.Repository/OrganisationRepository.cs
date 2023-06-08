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
    public class OrganisationRepository : IOrganisationRepository
    {
        public readonly IConfiguration _configuration;
        public OrganisationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<Organisation>> GetOrganisations()
        {
            var query = "SELECT * FROM Organisation";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var organisations = await connection.QueryAsync<Organisation>(query);
                connection.Close();
                return organisations.ToList();
            }

        }
    }
}
