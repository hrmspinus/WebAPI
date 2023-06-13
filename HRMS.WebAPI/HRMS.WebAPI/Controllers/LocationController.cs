using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILogger<LocationController> _logger;
        private ILocationRepository _locationrepo;
        public LocationController(ILogger<LocationController> logger, ILocationRepository locationrepo)
        {
            _logger = logger;
            _locationrepo = locationrepo;
        }

        [HttpGet(Name = "GetLocations")]
        public Task<IEnumerable<Location>> GetLocations()
        {
            return _locationrepo.GetLocations();

        }

        [HttpPost(Name = "CreateLocation")]
        public int CreateLocation(Location location)
        {
            return _locationrepo.CreateLocation(location.LocationName, location.CreatedBy);

        }
    }
}
