using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly ILogger<DepartmentController> _logger;
        private IDepartmentRepository _departmentrepo;
        public DepartmentController(ILogger<DepartmentController> logger, IDepartmentRepository departmentrepo)
        {
            _logger = logger;
            _departmentrepo = departmentrepo;
        }

        [HttpGet(Name = "GetDepartments")]
        public Task<IEnumerable<Department>> GetDepartments()
        {
            return _departmentrepo.GetDepartments();

        }

        [HttpPost(Name = "CreateDepartmentType")]
        public int CreateDepartmentType(Department department)
        {
            return _departmentrepo.CreateDepartmentType(department.DepartmentName, department.CreatedBy);
        }

        [HttpDelete(Name = "DeleteDepartment")]
        public int DeleteDepartment(int DepartmentID)
        {
            return _departmentrepo.DeleteDepartment(DepartmentID);
        }

        [HttpPut(Name = "UpdateDepartment")]
        public int UpdateDepartment(Department department)
        {
            return _departmentrepo.UpdateDepartment(department.DepartmentID, department.DepartmentName, department.CreatedBy);
        }
    }
}
