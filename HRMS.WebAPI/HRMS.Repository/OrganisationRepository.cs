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
    public class OrganisationRepository : IOrganisationRepository
    {
        public readonly IConfiguration _configuration;
        public OrganisationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<Organisation>> GetOrganisations()
        {
            var query = "SELECT * FROM Organisation";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var organisations = await connection.QueryAsync<Organisation>(query);
                connection.Close();
                return organisations.ToList();
            }

        }

        //public int CreateOrganisation(string OrganisationName, string OrganisationCode, string ContactPerson1, string MobileNumber1,
        //    string Email1, string ContactPerson2, string MobileNumber2, string Email2, string CountryCode, string PhoneNo, string Extn,
        //    string FaxNo, string Address, string CorrespondenceAddress, string City, string Country, string PinCode, string Email,
        //    string Website, string Remark, string CreatedBy)
        //{

        //    var connectionString = this.GetConnection();
        //    var parameters = new DynamicParameters();
        //    parameters.Add(name: "@v_AddressTypeName", value: AddressTypeName, dbType: DbType.String, direction: ParameterDirection.Input);
        //    parameters.Add(name: "@v_CreatedBy", value: CreatedBy, dbType: DbType.String, direction: ParameterDirection.Input);
        //    var connection = new SqlConnection(connectionString);


        //    return connection.Execute("[dbo].[usp_AddressTypeName_Insert]", parameters, commandType: CommandType.StoredProcedure);



        //}
    }
}
