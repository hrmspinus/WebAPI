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
    public class EmployeeQualificationRepository : IEmployeeQualificationRepository
    {
        public readonly IConfiguration _configuration;
        public EmployeeQualificationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<EmployeeQualification>> GetEmployeeQualifications(int EmployeeQualificationID)
        {

            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(name: "@i_EmployeeQualificationID", value: EmployeeQualificationID, dbType: DbType.Int16, direction: ParameterDirection.Input);
                var employeequalification = await connection.QueryAsync<EmployeeQualification>("[dbo].[usp_EmployeeQualification_Select]", parameters, commandType: CommandType.StoredProcedure); ;


                connection.Close();
                return employeequalification.ToList();
            }

        }


        public async Task<IEnumerable<EmployeeQualification>> GetAllEmployeeQualifications()
        {

            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var employeequalifications = await connection.QueryAsync<EmployeeQualification>("[dbo].[usp_EmployeeQualification_Select]", null, commandType: CommandType.StoredProcedure); ;



                connection.Close();
                return employeequalifications.ToList();
            }

        }

        public async Task<IEnumerable<EmployeeQualification>> GetDeleteEmployeeQualifications(int EmployeeQualificationID)
        {

            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var parameters = new DynamicParameters();
                parameters.Add(name: "@i_EmployeeQualificationID", value: EmployeeQualificationID, dbType: DbType.Int16, direction: ParameterDirection.Input);
                var employeequalifications = await connection.QueryAsync<EmployeeQualification>("[dbo].[usp_EmployeeQualification_Delete]", parameters, commandType: CommandType.StoredProcedure); ;

                connection.Close();
                return employeequalifications.ToList();
            }

        }







        public int CreateEmployeeQualifications(EmployeeQualification empQualifications)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@i_EmployeeID", value: empQualifications.EmployeeID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_DegreeName", value: empQualifications.DegreeName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_instituteName", value: empQualifications.instituteName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_UniversityName", value: empQualifications.UniversityName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_YearOfPassing", value: empQualifications.YearOfPassing, dbType: DbType.Date, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_Percentage", value: empQualifications.Percentage, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: empQualifications.CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_ModifiedBy", value: empQualifications.ModifiedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_EmployeeQualification_Insert]", parameters, commandType: CommandType.StoredProcedure);



        }



    }
}
