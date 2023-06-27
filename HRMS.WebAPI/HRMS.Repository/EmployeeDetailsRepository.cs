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


        public async Task<IEnumerable<EmployeeDetails>> GetDeleteEmployeeDetails(int EmployeeID)
        {

            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(name: "@i_EmployeeID", value: EmployeeID, dbType: DbType.Int16, direction: ParameterDirection.Input);
                var employeedetails = await connection.QueryAsync<EmployeeDetails>("[dbo].[usp_EmployeeDetail_Delete]", parameters, commandType: CommandType.StoredProcedure); ;

                connection.Close();
                return employeedetails.ToList();
            }

        }


        public int UpdateEmployeeDetails(EmployeeDetails empDetails)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@i_EmployeeID", value: empDetails.EmployeeID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_OrganisationID", value: empDetails.OrganisationID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_AutoNumber", value: empDetails.AutoNumber, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_FirstName", value: empDetails.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_MiddleName", value: empDetails.MiddleName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_LastName", value: empDetails.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@d_DateOfBirth", value: empDetails.DateOfBirth, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_Age", value: empDetails.Age, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_Gender", value: empDetails.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_Email", value: empDetails.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_PhoneNumber", value: empDetails.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_EmergencyContactNumber", value: empDetails.EmergencyContactNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_Location", value: empDetails.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_MaritalStatus", value: empDetails.MaritalStatus, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@d_HireDate", value: empDetails.HireDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_ManagerID", value: empDetails.ManagerID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_BusinessTitleID", value: empDetails.BusinessTitleID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_DepartmentID", value: empDetails.DepartmentID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_DesignationID", value: empDetails.DesignationID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_BloodGroupID", value: empDetails.BloodGroupID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: empDetails.CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_ModifiedBy", value: empDetails.ModifiedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);
            

            return connection.Execute("[dbo].[usp_EmployeeDetail_Update]", parameters, commandType: CommandType.StoredProcedure);



        }












        public int CreateEmployeeDetails(EmployeeDetails empDetails)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@i_OrganisationID", value: empDetails.OrganisationID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_AutoNumber", value: empDetails.AutoNumber, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_FirstName", value: empDetails.FirstName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_MiddleName", value: empDetails.MiddleName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_LastName", value: empDetails.LastName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@d_DateOfBirth", value: empDetails.DateOfBirth, dbType: DbType.Date, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_Age", value: empDetails.Age, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_Gender", value: empDetails.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_Email", value: empDetails.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_PhoneNumber", value: empDetails.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_EmergencyContactNumber", value: empDetails.EmergencyContactNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_Location", value: empDetails.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_MaritalStatus", value: empDetails.MaritalStatus, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@d_HireDate", value: empDetails.HireDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_ManagerID", value: empDetails.ManagerID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_BusinessTitleID", value: empDetails.BusinessTitleID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_DepartmentID", value: empDetails.DepartmentID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_DesignationID", value: empDetails.DesignationID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_BloodGroupID", value: empDetails.BloodGroupID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: empDetails.CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_ModifiedBy", value: empDetails.ModifiedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_EmployeeDetail_Insert]", parameters, commandType: CommandType.StoredProcedure);



        }
    }
}
