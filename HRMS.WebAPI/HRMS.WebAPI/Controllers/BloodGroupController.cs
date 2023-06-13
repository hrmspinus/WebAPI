using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BloodGroupController : Controller
    {
        private readonly ILogger<BloodGroupController> _logger;
        private IBloodGroupRepository _bloodgrouprepo;
        public BloodGroupController(ILogger<BloodGroupController> logger, IBloodGroupRepository bloodgrouprepo)
        {
            _logger = logger;
            _bloodgrouprepo = bloodgrouprepo;
        }

        [HttpGet(Name = "GetBloodGroups")]
        public Task<IEnumerable<BloodGroup>> GetBloodGroups()
        {
            return _bloodgrouprepo.GetBloodGroups();

        }

        [HttpPost(Name = "CreateBloodGroup")]
        public int CreateBloodGroup(BloodGroup bloodGroup)
        {
            return _bloodgrouprepo.CreateBloodGroup(bloodGroup.BloodGroupName, bloodGroup.CreatedBy);

        }
    }
}
