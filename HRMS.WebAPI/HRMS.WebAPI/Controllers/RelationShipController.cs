using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelationShipController : Controller
    {
        private readonly ILogger<RelationShipController> _logger;
        private IRelationShipRepository _relationshiprepo;
        public RelationShipController(ILogger<RelationShipController> logger, IRelationShipRepository relationshiprepo)
        {
            _logger = logger;
            _relationshiprepo = relationshiprepo;
        }

        [HttpGet(Name = "GetRelationShips")]
        public Task<IEnumerable<RelationShip>> GetRelationShips()
        {
            return _relationshiprepo.GetRelationShips();

        }

        [HttpPost(Name = "CreateRelationShip")]
        public int CreateRelationShip(RelationShip relationShip)
        {
            return _relationshiprepo.CreateRelationShip(relationShip.RelationShipName, relationShip.CreatedBy);

        }
    }
}
