using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppraisalObjectivesController : ControllerBase
    {
        private readonly ILogger<AppraisalObjectivesController> _logger;
        private IAppraisalObjectivesRepository _appraisalobjectivesrepo;
        public AppraisalObjectivesController(ILogger<AppraisalObjectivesController> logger, IAppraisalObjectivesRepository appraisalobjectivesrepo)
        {
            _logger = logger;
            _appraisalobjectivesrepo = appraisalobjectivesrepo;
        }

        [HttpGet(Name = "GetAppraisals")]
        public Task<IEnumerable<AppraisalObjectives>> GetAppraisals()
        {
            return _appraisalobjectivesrepo.GetAppraisals();

        }

        [HttpPost(Name = "CreateAppraisalObjectives")]
        public int CreateAppraisalObjectives(AppraisalObjectives appraisalObjectives)
        {
            return _appraisalobjectivesrepo.CreateAppraisalObjectives(appraisalObjectives.AppraisalName, appraisalObjectives.CreatedBy);
        }

        [HttpDelete(Name = "DeleteAppraisalObjectives")]
        public int DeleteAppraisalObjectives(int AppraisalID)
        {
            return _appraisalobjectivesrepo.DeleteAppraisalObjectives(AppraisalID);
        }

        [HttpPut(Name = "UpdateAppraisalObjectives")]
        public int UpdateAppraisalObjectives(AppraisalObjectives appraisalObjectives)
        {
            return _appraisalobjectivesrepo.UpdateAppraisalObjectives(appraisalObjectives.AppraisalID, appraisalObjectives.AppraisalName, appraisalObjectives.CreatedBy);
        }
    }
}
