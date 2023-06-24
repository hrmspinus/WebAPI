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
    public class EmployeeExperienceRepository : IEmployeeExperienceRepository
    {
        public readonly IConfiguration _configuration;
        public EmployeeExperienceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<EmployeeExperience>> GetEmployeeExperiences()
        {
            var query = "SELECT * FROM EmployeeExperience";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var employeeExperiences = await connection.QueryAsync<EmployeeExperience>(query);
                connection.Close();
                return employeeExperiences.ToList();
            }

        }

        public int CreateEmployeeExperiences(int EmployeeID, string CompanyName, string Designation,DateTime StartDate, 
            DateTime EndDate, int YearsWorked, int Salary, string CreatedBy, string ModifiedBy)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@i_EmployeeID", value: EmployeeID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CompanyName", value: CompanyName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_Designation", value: Designation, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@d_StartDate", value: StartDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            parameters.Add(name: "@d_EndDate", value: EndDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_YearsWorked", value: YearsWorked, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_Salary", value: Salary, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_ModifiedBy", value: ModifiedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);

            return connection.Execute("[dbo].[usp_EmployeeExperience_Insert]", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
