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
    public class HrmsPageRepository : IHrmsPageRepository
    {
        public readonly IConfiguration _configuration;
        public HrmsPageRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<HrmsPage>> GetHrmsPages()
        {
            var query = "SELECT * FROM HrmsPage";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var hrmspages = await connection.QueryAsync<HrmsPage>(query);
                connection.Close();
                return hrmspages.ToList();
            }

        }


        public int CreateHrmsPages(string PageName,int RoleID, string CreatedBy)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@v_PageName", value: PageName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@i_RoleID", value: RoleID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_HrmsPage_Insert]", parameters, commandType: CommandType.StoredProcedure);



        }
    }
}
