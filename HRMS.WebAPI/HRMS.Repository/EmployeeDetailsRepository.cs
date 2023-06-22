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
    public class EmployeeDetailsRepository : IEmployeeDetailsRepository
    {
        public readonly IConfiguration _configuration;
        public EmployeeDetailsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<EmployeeDetails>> GetEmployeeDetails()
        {
            var query = "SELECT * FROM EmployeeDetail";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var employeedetails = await connection.QueryAsync<EmployeeDetails>(query);
                connection.Close();
                return employeedetails.ToList();
            }

        }


        public int CreateEmployeeDetails(string FirstName, string MiddleName, string LastName,DateTime DateOfBirth, 
            int Age, string Gender, string Email, string PhoneNumber, string EmergencyContactNumber,string Location, 
            string MaritalStatus)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@v_FirstName", value: FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_MiddleName", value: MiddleName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_LastName", value: LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@d_DateOfBirth", value: DateOfBirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_Age", value: Age, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_Gender", value: Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_Email", value: Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_PhoneNumber", value: PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_EmergencyContactNumber", value: EmergencyContactNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_Location", value: Location, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_MaritalStatus", value: MaritalStatus, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_EmployeeDetail_Insert]", parameters, commandType: CommandType.StoredProcedure);



        }
    }
}
