using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IHrmsUserRepository 
    {
        Task<IEnumerable<HrmsUser>> GetHrmsUsers();
        int CreateHrmsUser(string UserName,string FirstName,string LastName, string MiddleName,int RoleID, string CreatedBy);
    }
}
