using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class HrmsUser
    {
        public int HrmsUserID { get; set; }
        public string UserName { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int RoleID { get; set; }
        public string CreatedBy { get; set; }
    }
}
