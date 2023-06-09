using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HrmsPageController : ControllerBase
    {
        private readonly ILogger<HrmsPageController> _logger;
        private IHrmsPageRepository _hrmspagerepo;
        public HrmsPageController(ILogger<HrmsPageController> logger, IHrmsPageRepository hrmspagerepo)
        {
            _logger = logger;
            _hrmspagerepo = hrmspagerepo;
        }

        [HttpGet(Name = "GetHrmsPages")]
        public Task<IEnumerable<HrmsPage>> GetHrmsPages()
        {
            return _hrmspagerepo.GetHrmsPages();

        }

        [HttpPost(Name = "CreateHrmsPages")]
        public int CreateHrmsPages(HrmsPage hrmsPage)
        {
            return _hrmspagerepo.CreateHrmsPages(hrmsPage.PageName,hrmsPage.RoleID, hrmsPage.CreatedBy);

        }
    }
}
