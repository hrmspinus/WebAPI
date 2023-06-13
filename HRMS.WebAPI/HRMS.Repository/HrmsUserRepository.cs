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
    public class HrmsUserRepository : IHrmsUserRepository
    {
        public readonly IConfiguration _configuration;
        public HrmsUserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<HrmsUser>> GetHrmsUsers()
        {
            var query = "SELECT * FROM HrmsUser";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var hrmsusers = await connection.QueryAsync<HrmsUser>(query);
                connection.Close();
                return hrmsusers.ToList();
            }

        }


        public int CreateHrmsUser(string UserName, string FirstName, string LastName, string MiddleName,string RoleName, int RoleID, string CreatedBy)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@v_UserName", value: UserName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_FirstName", value: FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_LastName", value: LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_MiddleName", value: MiddleName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_RoleName", value: RoleName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_RoleID", value: RoleID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_HrmsUser_Insert]", parameters, commandType: CommandType.StoredProcedure);

        }
    }
}
