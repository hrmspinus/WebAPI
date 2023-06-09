using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HrmsUserController : ControllerBase
    {
        private readonly ILogger<HrmsUserController> _logger;
        private IHrmsUserRepository _hrmsuserrepo;
        public HrmsUserController(ILogger<HrmsUserController> logger, IHrmsUserRepository hrmsuserrepo)
        {
            _logger = logger;
            _hrmsuserrepo = hrmsuserrepo;
        }

        [HttpGet(Name = "GetHrmsUsers")]
        public Task<IEnumerable<HrmsUser>> GetHrmsUsers()
        {
            return _hrmsuserrepo.GetHrmsUsers();

        }

        [HttpPost(Name = "CreateHrmsUser")]
        public int CreateHrmsUser(HrmsUser hrmsUser)
        {
            return _hrmsuserrepo.CreateHrmsUser(hrmsUser.UserName,hrmsUser.FirstName,hrmsUser.LastName,hrmsUser.MiddleName,
                hrmsUser.RoleID, hrmsUser.CreatedBy);

        }

    }
}
