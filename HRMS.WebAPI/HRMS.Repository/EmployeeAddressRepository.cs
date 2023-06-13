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
    public class EmployeeAddressRepository : IEmployeeAddressRepository
    {
        public readonly IConfiguration _configuration;
        public EmployeeAddressRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<EmployeeAddress>> GetEmployeeAddress()
        {
            var query = "SELECT * FROM EmployeeAddress";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var employeeaddress = await connection.QueryAsync<EmployeeAddress>(query);
                connection.Close();
                return employeeaddress.ToList();
            }

        }


        //public int CreateEmployeeAddress(string CreatedBy)
        //{

        //    var connectionString = this.GetConnection();
        //    var parameters = new DynamicParameters();
        //    parameters.Add(name: "@v_UserName", value: UserName, dbType: DbType.String, direction: ParameterDirection.Input);
        //    parameters.Add(name: "@v_FirstName", value: FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
        //    parameters.Add(name: "@v_LastName", value: LastName, dbType: DbType.String, direction: ParameterDirection.Input);
        //    parameters.Add(name: "@v_MiddleName", value: MiddleName, dbType: DbType.String, direction: ParameterDirection.Input);
        //    parameters.Add(name: "@i_RoleID", value: RoleID, dbType: DbType.Int16, direction: ParameterDirection.Input);
        //    parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
        //    var connection = new SqlConnection(connectionString);


        //    return connection.Execute("[dbo].[usp_HrmsUser_Insert]", parameters, commandType: CommandType.StoredProcedure);

        //}
    }
}
