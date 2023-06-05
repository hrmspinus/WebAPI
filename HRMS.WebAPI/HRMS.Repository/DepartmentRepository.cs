using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
    }
}
