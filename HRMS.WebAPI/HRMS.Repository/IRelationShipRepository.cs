using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IRelationShipRepository
    {
        Task<IEnumerable<RelationShip>> GetRelationShips();
        int CreateRelationShip(string RelationShipName, string CreatedBy);
    }
}
