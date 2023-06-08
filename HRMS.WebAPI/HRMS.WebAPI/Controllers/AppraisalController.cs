using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppraisalController : ControllerBase
    {
        private readonly ILogger<AppraisalController> _logger;
        private IAppraisalRepository _appraisalrepo;
        public AppraisalController(ILogger<AppraisalController> logger, IAppraisalRepository appraisalrepo)
        {
            _logger = logger;
            _appraisalrepo = appraisalrepo;
        }

        [HttpGet(Name = "GetAppraisals")]
        public Task<IEnumerable<Appraisal>> GetAppraisals()
        {
            return _appraisalrepo.GetAppraisals();

        }
    }
}
