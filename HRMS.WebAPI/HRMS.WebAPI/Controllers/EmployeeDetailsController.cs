using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeDetailsController : ControllerBase
    {
        private readonly ILogger<EmployeeDetailsController> _logger;
        private IEmployeeDetailsRepository _employeedetailsrepo;
        public EmployeeDetailsController(ILogger<EmployeeDetailsController> logger, IEmployeeDetailsRepository employeedetailsrepo)
        {
            _logger = logger;
            _employeedetailsrepo = employeedetailsrepo;
        }

        [HttpGet("GetEmployeeDetails")]
        public Task<IEnumerable<EmployeeDetails>> GetEmployeeDetails(int EmployeeID)
        {
            return _employeedetailsrepo.GetEmployeeDetails(EmployeeID);

        }


        [HttpGet("GetAllEmployeeDetails")]
        public Task<IEnumerable<EmployeeDetails>> GetAllEmployeeDetails()
        {
            return _employeedetailsrepo.GetAllEmployeeDetails();

        }

        [HttpPost(Name = "CreateEmployeeDetails")]
        public int CreateEmployeeDetails(EmployeeDetails empDetails)
        {
            return _employeedetailsrepo.CreateEmployeeDetails(empDetails);

        }


        [HttpDelete("GetDeleteEmployeeDetails")]
        public Task<IEnumerable<EmployeeDetails>> GetDeleteEmployeeDetails(int EmployeeID)
        {
            return _employeedetailsrepo.GetDeleteEmployeeDetails(EmployeeID);

        }


        [HttpPut(Name = "UpdateEmployeeDetails")]
        public int UpdateEmployeeDetails(EmployeeDetails empDetails)
        {
            return _employeedetailsrepo.UpdateEmployeeDetails(empDetails);

        }

    }
}
