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
        int DeleteHrmsRole(int RoleID);
        int UpdateHrmsRole(int RoleID,string RoleName, string CreatedBy);
    }
}
