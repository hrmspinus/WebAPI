using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IBloodGroupRepository
    {
        Task<IEnumerable<BloodGroup>> GetBloodGroups();
        int CreateBloodGroup(string BloodGroupName, string CreatedBy);
    }
}
