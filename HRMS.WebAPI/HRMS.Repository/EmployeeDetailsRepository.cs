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
        public async Task<IEnumerable<EmployeeDetails>> GetEmployeeDetails(int EmployeeID)
        {
           
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(name: "@i_EmployeeID", value: EmployeeID, dbType: DbType.Int16, direction: ParameterDirection.Input);
                var employeedetails = await connection.QueryAsync<EmployeeDetails>("[dbo].[usp_EmployeeDetail_Select]", parameters, commandType: CommandType.StoredProcedure); ;

              

                connection.Close();
                return employeedetails.ToList();
            }

        }



        public async Task<IEnumerable<EmployeeDetails>> GetAllEmployeeDetails()
        {
            
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var employeedetails = await connection.QueryAsync<EmployeeDetails>("[dbo].[usp_EmployeeDetail_Select]", null, commandType: CommandType.StoredProcedure); ;



                connection.Close();
                return employeedetails.ToList();
            }

        }


        public int CreateEmployeeDetails(EmployeeDetails empDetail)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@i_OrganisationID", value: empDetail.OrganisationID, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_FirstName", value: empDetail.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_MiddleName", value: empDetail.MiddleName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_LastName", value: empDetail.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@d_DateOfBirth", value: empDetail.DateOfBirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_Age", value: empDetail.Age, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_Gender", value: empDetail.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_Email", value: empDetail.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_PhoneNumber", value: empDetail.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_EmergencyContactNumber", value: empDetail.EmergencyContactNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_Location", value: empDetail.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_MaritalStatus", value: empDetail.MaritalStatus, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@d_HireDate", value: empDetail.HireDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_ManagerID", value: empDetail.ManagerID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_BusinessTitleID", value: empDetail.BusinessTitleID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_DepartmentID", value: empDetail.DepartmentID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_DesignationID", value: empDetail.DesignationID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_BloodGroupID", value: empDetail.BloodGroupID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: empDetail.CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_ModifiedBy", value: empDetail.ModifiedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_EmployeeDetail_Insert]", parameters, commandType: CommandType.StoredProcedure);



        }
    }
}
