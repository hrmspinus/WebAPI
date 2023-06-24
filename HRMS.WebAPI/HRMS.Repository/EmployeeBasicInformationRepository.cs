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
    public class EmployeeBasicInformationRepository : IEmployeeBasicInformationRepository
    {
        public readonly IConfiguration _configuration;
        public EmployeeBasicInformationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<EmployeeBasicInformation>> GetEmployeeBasicInformations()
        {
            var query = "SELECT * FROM EmployeeBasicInformation";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var employeebasicinformation = await connection.QueryAsync<EmployeeBasicInformation>(query);
                connection.Close();
                return employeebasicinformation.ToList();
            }

        }

        public int CreateEmployeeBasicInformation(string Name, string FatherName, DateTime DateOfBirth, int Age, string Gender, 
            string PhoneNo,string Email, string HomeAddress, string CityOfBirth, string CountryOfBirth, string MaritalStatus, 
            DateTime WeddingDate,string PrimaryNationality)
        {
            var connectionString = this.GetConnection();
            var parameters = new DynamicParameters();
            parameters.Add(name: "", value: Name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "", value: FatherName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "", value: DateOfBirth, dbType: DbType.Date, direction: ParameterDirection.Input);
            parameters.Add(name: "", value: Age, dbType: DbType.Int16, direction: ParameterDirection.Input);
            parameters.Add(name: "", value: Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "", value: PhoneNo, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "", value: Email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "", value: HomeAddress, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "", value: CityOfBirth, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "", value: CountryOfBirth, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "", value: MaritalStatus, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add(name: "", value: WeddingDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            parameters.Add(name: "", value: PrimaryNationality, dbType: DbType.String, direction: ParameterDirection.Input);
            var connection = new SqlConnection(connectionString);


            return connection.Execute("[dbo].[usp_EmployeeBasicInformation_Insert]", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
