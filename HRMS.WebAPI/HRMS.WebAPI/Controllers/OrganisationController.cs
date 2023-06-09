using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrganisationController : ControllerBase
    {
        private readonly ILogger<OrganisationController> _logger;
        private IOrganisationRepository _organisationrepo;
        public OrganisationController(ILogger<OrganisationController> logger, IOrganisationRepository organisationrepo)
        {
            _logger = logger;
            _organisationrepo = organisationrepo;
        }

        [HttpGet(Name = "GetOrganisations")]
        public Task<IEnumerable<Organisation>> GetOrganisations()
        {
            return _organisationrepo.GetOrganisations();

        }

        //[HttpPost(Name = "CreateAddressType")]
        //public int CreateAddressType(AddressType addressType)
        //{
        //    return _organisationrepo.CreateAddressType(addressType.AddressTypeName, addressType.CreatedBy);

        //}

    }

}
