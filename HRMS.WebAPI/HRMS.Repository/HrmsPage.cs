using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class HrmsPage
    {
        public int PageID { get; set; }
        public string PageName { get; set; }
        public int RoleID { get; set; }
        public string CreatedBy { get; set; }
    }
}
