using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class EmployeeQualification
    {
        public int EmployeeQualificationID { get; set; }
        public int EmployeeID { get; set; }
        public string DegreeName { get; set; }
        public string instituteName { get; set; }

    }
}
