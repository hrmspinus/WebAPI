using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace HRMS.Repository
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
    public interface ILeaveTypeNameRepository
    {
        Task<IEnumerable<LeaveType>> GetLeaveTypes();
       
    }
    public class LeaveTypeNameRepository : ILeaveTypeNameRepository
    {
        
        private readonly IConfiguration _configuration;
        public LeaveTypeNameRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }
        public async Task<IEnumerable<LeaveType>> GetLeaveTypes()
        {
            var query = "SELECT * FROM LeaveType";
            var connectionString = this.GetConnection();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var leavetypes = await connection.QueryAsync<LeaveType>(query);
                connection.Close();
                return leavetypes.ToList();
            }
            
        }

       
    }
}