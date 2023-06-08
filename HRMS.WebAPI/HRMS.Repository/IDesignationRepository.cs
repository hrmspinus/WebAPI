using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IDesignationRepository
    {
        Task<IEnumerable<Designation>> GetDesignations();
        int CreateDesignationType(string DesignationName, string CreatedBy);
    }
}
