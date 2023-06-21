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
    public class AppraisalObjectivesRepository : IAppraisalObjectivesRepository
    {
        private readonly IConfiguration _configuration;
        public AppraisalObjectivesRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<AppraisalObjectives>> GetAppraisals()
        {
            var query = "SELECT * FROM AppraisalObjectives";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var appraisalobjectives = await connection.QueryAsync<AppraisalObjectives>(query);
                connection.Close();
                return appraisalobjectives.ToList();
            }

        }

        public int CreateAppraisalObjectives(string AppraisalName, string CreatedBy)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@v_AppraisalName", value: AppraisalName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_AppraisalObjectives_Insert]", parameters, commandType: CommandType.StoredProcedure);



        }
    }
}
