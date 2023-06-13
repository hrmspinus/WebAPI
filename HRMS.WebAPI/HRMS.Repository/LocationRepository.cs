using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly IConfiguration _configuration;
        public LocationRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<Location>> GetLocations()
        {
            var query = "SELECT * FROM Location";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var locations = await connection.QueryAsync<Location>(query);
                connection.Close();
                return locations.ToList();
            }

        }

        public int CreateLocation(string LocationName, string CreatedBy)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@v_LocationName", value: LocationName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_Location_Insert]", parameters, commandType: CommandType.StoredProcedure);



        }
    }
}
