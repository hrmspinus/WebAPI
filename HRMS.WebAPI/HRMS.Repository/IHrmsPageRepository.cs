using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IHrmsPageRepository
    {
        Task<IEnumerable<HrmsPage>> GetHrmsPages();
        int CreateHrmsPages(string PageName,int RoleID, string CreatedBy);
    }
}
