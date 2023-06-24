using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeFamilyDetailsController : ControllerBase
    {
        private readonly ILogger<EmployeeFamilyDetailsController> _logger;
        private IEmployeeFamilyDetailsRepository _employeefamilydetailsrepo;
        public EmployeeFamilyDetailsController(ILogger<EmployeeFamilyDetailsController> logger, IEmployeeFamilyDetailsRepository employeefamilydetailsrepo)
        {
            _logger = logger;
            _employeefamilydetailsrepo = employeefamilydetailsrepo;
        }

        [HttpGet(Name = "GetEmployeeFamilyDetails")]
        public Task<IEnumerable<EmployeeFamilyDetails>> GetEmployeeFamilyDetails()
        {
            return _employeefamilydetailsrepo.GetEmployeeFamilyDetails();

        }

        [HttpPost(Name = "CreateEmployeeFamilyDetails")]
        public int CreateEmployeeFamilyDetails(EmployeeFamilyDetails employeeFamilyDetails)
        {
            return _employeefamilydetailsrepo.CreateEmployeeFamilyDetails(employeeFamilyDetails.EmployeeID,
                employeeFamilyDetails.Name,employeeFamilyDetails.RelationShip,employeeFamilyDetails.Age,employeeFamilyDetails.DOB,
                employeeFamilyDetails.ContactNo,employeeFamilyDetails.CreatedBy,employeeFamilyDetails.ModifiedBy);

        }
    }
}
