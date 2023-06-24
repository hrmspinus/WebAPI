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

        [HttpGet(Name = "GetEmployeeDetails")]
        public Task<IEnumerable<EmployeeDetails>> GetEmployeeDetails()
        {
            return _employeedetailsrepo.GetEmployeeDetails();

        }

        [HttpPost(Name = "CreateEmployeeDetails")]
        public int CreateEmployeeDetails(EmployeeDetails employeeDetails)
        {
            return _employeedetailsrepo.CreateEmployeeDetails(employeeDetails);
        }
    }
}
