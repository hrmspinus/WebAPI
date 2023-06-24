using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BloodGroupController : ControllerBase
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

        [HttpDelete(Name = "DeleteBloodGroup")]
        public int DeleteBloodGroup(int BloodGroupID)
        {
            return _bloodgrouprepo.DeleteBloodGroup(BloodGroupID);
        }

        [HttpPut(Name = "UpdateBloodGroup")]
        public int UpdateBloodGroup(BloodGroup bloodGroup)
        {
            return _bloodgrouprepo.UpdateBloodGroup(bloodGroup.BloodGroupID, bloodGroup.BloodGroupName, bloodGroup.CreatedBy);
        }
    }
}
