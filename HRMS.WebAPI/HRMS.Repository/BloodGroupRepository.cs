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
    public class BloodGroupRepository : IBloodGroupRepository 
    {
        private readonly IConfiguration _configuration;
        public BloodGroupRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<BloodGroup>> GetBloodGroups()
        {
            var query = "SELECT * FROM BloodGroup";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var bloodgroups = await connection.QueryAsync<BloodGroup>(query);
                connection.Close();
                return bloodgroups.ToList();
            }

        }

        public int CreateBloodGroup(string BloodGroupName, string CreatedBy)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@v_BloodGroupName", value: BloodGroupName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_BloodGroup_Insert]", parameters, commandType: CommandType.StoredProcedure);
        }

        public int DeleteBloodGroup(int BloodGroupID)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@i_BloodGroupID", value: BloodGroupID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_BloodGroup_Delete]", parameters, commandType: CommandType.StoredProcedure);
        }

        public int UpdateBloodGroup(int BloodGroupID, string BloodGroupName, string CreatedBy)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@i_BloodGroupID", value: BloodGroupID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_BloodGroupName", value: BloodGroupName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_BloodGroup_Update]", parameters, commandType: CommandType.StoredProcedure);

        }
    }
}
