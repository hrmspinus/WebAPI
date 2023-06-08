using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressTypeController : ControllerBase
    {
        private readonly ILogger<AddressTypeController> _logger;
        private IAddressTypeRepository _addresstyperepo;
        public AddressTypeController(ILogger<AddressTypeController> logger, IAddressTypeRepository addresstyperepo)
        {
            _logger = logger;
            _addresstyperepo = addresstyperepo;
        }

        [HttpGet(Name = "GetAddresstypes")]
        public Task<IEnumerable<AddressType>> GetAddresstypes()
        {
            return _addresstyperepo.GetAddressTypes();

        }

        [HttpPost(Name = "CreateAddressType")]
        public int CreateAddressType(AddressType addressType)
        {
            return _addresstyperepo.CreateAddressType(addressType.AddressTypeName, addressType.CreatedBy);

        }
    }
}
