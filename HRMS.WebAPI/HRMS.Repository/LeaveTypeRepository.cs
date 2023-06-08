using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {

        private readonly IConfiguration _configuration;
        public LeaveTypeRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<LeaveType>> GetLeaveTypes()
        {
            var query = "SELECT * FROM LeaveType";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var leavetypes = await connection.QueryAsync<LeaveType>(query);
                connection.Close();
                return leavetypes.ToList();
            }

        }

        public int CreateLeaveType(string LeaveTypeName, string CreatedBy)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@v_LeaveTypeName", value: LeaveTypeName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_LeaveType_Insert]", parameters, commandType: CommandType.StoredProcedure);
             


        }


    }
}
