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
    public class HrmsRoleRepository : IHrmsRoleRepository
    {
        public readonly IConfiguration _configuration;
        public HrmsRoleRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<HrmsRole>> GetHrmsRoles()
        {
            var query = "SELECT * FROM HrmsRole";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var hrmsroles = await connection.QueryAsync<HrmsRole>(query);
                connection.Close();
                return hrmsroles.ToList();
            }
        }

        public int CreateHrmsRole(string RoleName, string CreatedBy)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@v_RoleName", value: RoleName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_HrmsRole_Insert]", parameters, commandType: CommandType.StoredProcedure);
        }

        public int DeleteHrmsRole(int RoleID)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@i_RoleID", value: RoleID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_HrmsRole_Delete]", parameters, commandType: CommandType.StoredProcedure);
        }

        public int UpdateHrmsRole(int RoleID,string RoleName, string CreatedBy)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@i_RoleID", value: RoleID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_RoleName", value: RoleName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_HrmsRole_Update]", parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
