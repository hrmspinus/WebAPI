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
    public class ClaimTypeRepository : IClaimTypeRepository
    {
        private readonly IConfiguration _configuration;
        public ClaimTypeRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<ClaimType>> GetClaimTypes()
        {
            var query = "SELECT * FROM ClaimType";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var claimtypes = await connection.QueryAsync<ClaimType>(query);
                connection.Close();
                return claimtypes.ToList();
            }

        }

        public int CreateClaimType(string ClaimTypeName, string CreatedBy)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@v_ClaimTypeName", value: ClaimTypeName , dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_ClaimType_Insert]", parameters, commandType: CommandType.StoredProcedure);



        }
    }
}
