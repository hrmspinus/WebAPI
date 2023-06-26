using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeQualificationController : ControllerBase
    {
        private readonly ILogger<EmployeeQualificationController> _logger;
        private IEmployeeQualificationRepository _employeequalificationsrepo;
        public EmployeeQualificationController(ILogger<EmployeeQualificationController> logger, IEmployeeQualificationRepository employeequalificationsrepo)
        {
            _logger = logger;
            _employeequalificationsrepo = employeequalificationsrepo;
        }

        [HttpGet("GetEmployeeQualifications")]
        public Task<IEnumerable<EmployeeQualification>> GetEmployeeQualifications(int EmployeeQualificationID)
        {
            return _employeequalificationsrepo.GetEmployeeQualifications(EmployeeQualificationID);

        }

        [HttpGet("GetAllEmployeeQualifications")]
        public Task<IEnumerable<EmployeeQualification>> GetAllEmployeeQualifications()
        {
            return _employeequalificationsrepo.GetAllEmployeeQualifications();

        }


        [HttpPost(Name = "CreateEmployeeQualifications")]
        public int CreateEmployeeQualifications(EmployeeQualification empQualifications)
        {
            return _employeequalificationsrepo.CreateEmployeeQualifications(empQualifications);

        }

        [HttpDelete("GetDeleteEmployeeQualifications")]
        public Task<IEnumerable<EmployeeQualification>> GetDeleteEmployeeQualifications(int EmployeeQualificationID)
        {
            return _employeequalificationsrepo.GetDeleteEmployeeQualifications(EmployeeQualificationID);

        }
    }
}
