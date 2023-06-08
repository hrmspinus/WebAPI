using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplyLeaveController : ControllerBase
    {
        private readonly ILogger<ApplyLeaveController> _logger;
        private IApplyLeaveRepository _applyleaverepo;
        public ApplyLeaveController(ILogger<ApplyLeaveController> logger, IApplyLeaveRepository applyleaverepo)
        {
            _logger = logger;
            _applyleaverepo = applyleaverepo;
        }

        [HttpGet(Name = "GetApplyLeaves")]
        public Task<IEnumerable<ApplyLeave>> GetApplyLeaves()
        {
            return _applyleaverepo.GetApplyLeaves();

        }
    }
}
