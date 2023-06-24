using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeBasicInformationController : ControllerBase
    {
        private readonly ILogger<EmployeeBasicInformationController> _logger;
        private IEmployeeBasicInformationRepository _employeebasicinformationsrepo;
        public EmployeeBasicInformationController(ILogger<EmployeeBasicInformationController> logger, IEmployeeBasicInformationRepository employeebasicinformationsrepo)
        {
            _logger = logger;
            _employeebasicinformationsrepo = employeebasicinformationsrepo;
        }

        [HttpGet(Name = "GetEmployeeBasicInformations")]
        public Task<IEnumerable<EmployeeBasicInformation>> GetEmployeeBasicInformations()
        {
            return _employeebasicinformationsrepo.GetEmployeeBasicInformations();

        }

        //[HttpPost(Name = "CreateEmployeeBasicInformation")]
        //public int CreateEmployeeBasicInformation(EmployeeBasicInformation employeeBasicInformation)
        //{
        //    return _employeebasicinformationsrepo.CreateEmployeeBasicInformation(employeeBasicInformation.Name,
        //        employeeBasicInformation.FatherName,employeeBasicInformation.DateOfBirth,employeeBasicInformation.Age,
        //        employeeBasicInformation.Gender,employeeBasicInformation.PhoneNo,employeeBasicInformation.Email,
        //        employeeBasicInformation.HomeAddress,employeeBasicInformation.CityOfBirth,employeeBasicInformation.CountryOfBirth,
        //        employeeBasicInformation.MaritalStatus,employeeBasicInformation.WeddingDate,employeeBasicInformation.PrimaryNationality);
        //}
    }
}
