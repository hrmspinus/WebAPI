using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetLocations();
        int CreateLocation(string LocationName, string CreatedBy);
    }
}
