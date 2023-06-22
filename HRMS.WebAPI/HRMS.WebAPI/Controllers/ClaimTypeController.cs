using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaimTypeController : ControllerBase
    {
        private readonly ILogger<ClaimTypeController> _logger;
        private IClaimTypeRepository _claimtyperepo;
        public ClaimTypeController(ILogger<ClaimTypeController> logger, IClaimTypeRepository claimtyperepo)
        {
            _logger = logger;
            _claimtyperepo = claimtyperepo;
        }

        [HttpGet(Name = "GetClaimTypes")]
        public Task<IEnumerable<ClaimType>> GetClaimTypes()
        {
            return _claimtyperepo.GetClaimTypes();

        }

        [HttpPost(Name = "CreateClaimType")]
        public int CreateClaimType(ClaimType claimType)
        {
            return _claimtyperepo.CreateClaimType(claimType.ClaimTypeName, claimType.CreatedBy);
        }

        [HttpDelete(Name = "DeleteClaimType")]
        public int DeleteClaimType(int ClaimTypeID)
        {
            return _claimtyperepo.DeleteClaimType(ClaimTypeID);
        }

        [HttpPut(Name = "UpdateClaimType")]
        public int UpdateClaimType(ClaimType claimType)
        {
            return _claimtyperepo.UpdateClaimType(claimType.ClaimTypeID, claimType.ClaimTypeName, claimType.CreatedBy);
        }
    }
}
