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
    public class AddressTypeRepository : IAddressTypeRepository
    {
        public readonly IConfiguration _configuration;
        public AddressTypeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<AddressType>> GetAddressTypes()
        {
            var query = "SELECT * FROM AddressType";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var addresstypes = await connection.QueryAsync<AddressType>(query);
                connection.Close();
                return addresstypes.ToList();
            }

        }


        public int CreateAddressType(string AddressTypeName, string CreatedBy)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@v_AddressTypeName", value: AddressTypeName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_AddressTypeName_Insert]", parameters, commandType: CommandType.StoredProcedure);

        }

        public int DeleteAddressType(int AddressTypeID)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@i_AddressTypeID", value: AddressTypeID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_AddressType_Delete]", parameters, commandType: CommandType.StoredProcedure);



        }

        public int UpdateAddressType(int AddressTypeID, string AddressTypeName, string CreatedBy)
        {

            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "@i_AddressTypeID", value: AddressTypeID, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_AddressTypeName", value: AddressTypeName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_AddressType_Update]", parameters, commandType: CommandType.StoredProcedure);



        }
    }
}
