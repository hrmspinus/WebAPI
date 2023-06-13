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
    public class RelationShipRepository : IRelationShipRepository
    {
        private readonly IConfiguration _configuration;
        public RelationShipRepository(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<RelationShip>> GetRelationShips()
        {
            var query = "SELECT * FROM RelationShip";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var relationships = await connection.QueryAsync<RelationShip>(query);
                connection.Close();
                return relationships.ToList();
            }

        }

        public int CreateRelationShip(string RelationShipName, string CreatedBy)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@v_RelationShipName", value: RelationShipName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_RelationShip_Insert]", parameters, commandType: CommandType.StoredProcedure);



        }
    }
}
