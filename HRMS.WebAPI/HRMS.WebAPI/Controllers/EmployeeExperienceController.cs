using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EmployeeExperienceController : ControllerBase
    {
        private readonly ILogger<EmployeeExperienceController> _logger;
        private IEmployeeExperienceRepository _employeeexperiencerepo;
        public EmployeeExperienceController(ILogger<EmployeeExperienceController> logger, IEmployeeExperienceRepository employeeexperiencerepo)
        {
            _logger = logger;
            _employeeexperiencerepo = employeeexperiencerepo;
        }

        [HttpGet(Name = "GetEmployeeExperiences")]
        public Task<IEnumerable<EmployeeExperience>> GetEmployeeExperiences()
        {
            return _employeeexperiencerepo.GetEmployeeExperiences();

        }

        [HttpPost(Name = "CreateEmployeeExperiences")]
        public int CreateEmployeeExperiences(EmployeeExperience employeeExperience)
        {
            return _employeeexperiencerepo.CreateEmployeeExperiences(employeeExperience.EmployeeID,employeeExperience.CompanyName,
                employeeExperience.Designation,employeeExperience.StartDate,employeeExperience.EndDate,
                employeeExperience.YearsWorked,employeeExperience.Salary, employeeExperience.CreatedBy, 
                employeeExperience.ModifiedBy);
        }
    }
}
