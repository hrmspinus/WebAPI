using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DesignationController : ControllerBase
    {
        
        private readonly ILogger<DesignationController> _logger;
        private IDesignationRepository _designationrepo;
        public DesignationController(ILogger<DesignationController> logger, IDesignationRepository designationrepo)
        {
            _logger = logger;
            _designationrepo = designationrepo;
        }

        [HttpGet(Name = "GetDesignations")]
        public Task<IEnumerable<Designation>> GetDesignations()
        {
            return _designationrepo.GetDesignations();

        }
    }
}
