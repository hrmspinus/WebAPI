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
            return _employeedetailsrepo.CreateEmployeeDetails(employeeDetails.OrganisationID,employeeDetails.AutoNumber,
                employeeDetails.FirstName,employeeDetails.MiddleName,employeeDetails.LastName,employeeDetails.DateOfBirth,
                employeeDetails.Age,employeeDetails.Gender,employeeDetails.Email,employeeDetails.PhoneNumber,
                employeeDetails.EmergencyContactNumber,employeeDetails.Location,employeeDetails.MaritalStatus,
                employeeDetails.HireDate,employeeDetails.LengthOfService,employeeDetails.FTE,employeeDetails.ManagerID,
                employeeDetails.BusinessTitleID,employeeDetails.DepartmentID,employeeDetails.DesignationID,employeeDetails.BloodGroupID,
                employeeDetails.CreatedBy,employeeDetails.ModifiedBy);
        }
    }
}
