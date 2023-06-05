using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaveTypeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<LeaveTypeController> _logger;
        private ILeaveTypeRepository _leavetyperepo;
        public LeaveTypeController(ILogger<LeaveTypeController> logger, ILeaveTypeRepository leavetyperepo)
        {
            _logger = logger;
            _leavetyperepo = leavetyperepo;
        }

        [HttpGet(Name = "GetLeaveTypes")]
        public Task<IEnumerable<LeaveType>> GetLeaveTypes()
        {
            return _leavetyperepo.GetLeaveTypes();
          
        }
    }
}