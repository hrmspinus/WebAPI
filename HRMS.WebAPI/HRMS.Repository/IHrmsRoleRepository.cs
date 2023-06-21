using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IHrmsRoleRepository
    {
        Task<IEnumerable<HrmsRole>> GetHrmsRoles();
        int CreateHrmsRole(string RoleName, string CreatedBy);
        //int DeleteHrmsrole(int roleid);
    }
}
