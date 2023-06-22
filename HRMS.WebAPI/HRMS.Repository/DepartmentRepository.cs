using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public readonly IConfiguration _configuration;
        public DepartmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            var query = "SELECT * FROM Department";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var departments = await connection.QueryAsync<Department>(query);
                connection.Close();
                return departments.ToList();
            }
        }

        public int CreateDepartmentType(string DepartmentName, string CreatedBy)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@v_DepartmentName", value: DepartmentName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_Department_Insert]", parameters, commandType: CommandType.StoredProcedure);
        }

        public int DeleteDepartment(int DepartmentID)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@i_DepartmentID", value: DepartmentID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_Department_Delete]", parameters, commandType: CommandType.StoredProcedure);
        }

        public int UpdateDepartment(int DepartmentID, string DepartmentName, string CreatedBy)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@i_DepartmentID", value: DepartmentID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_DepartmentName", value: DepartmentName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_Department_Update]", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
