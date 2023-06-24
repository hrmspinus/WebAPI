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
    public class EmployeeFamilyDetailsRepository : IEmployeeFamilyDetailsRepository
    {
        public readonly IConfiguration _configuration;
        public EmployeeFamilyDetailsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<EmployeeFamilyDetails>> GetEmployeeFamilyDetails()
        {
            var query = "SELECT * FROM EmployeeFamilyDetail";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var employeefamilydetail = await connection.QueryAsync<EmployeeFamilyDetails>(query);
                connection.Close();
                return employeefamilydetail.ToList();
            }

        }

        public int CreateEmployeeFamilyDetails(int EmployeeID, string Name, string RelationShip, int Age, DateTime DOB, 
            string ContactNo, string CreatedBy, string ModifiedBy)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@i_EmployeeID", value: EmployeeID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_Name", value: Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_RelationShip", value: RelationShip, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_Age", value: Age, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@D_DOB", value: DOB, dbType: DbType.Date, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_ContactNo", value: ContactNo, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_ModifiedBy", value: ModifiedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_EmployeeFamilyDetail_Insert]", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
