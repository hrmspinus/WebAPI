using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class Appraisal
    {
        public int AppraisalID { get; set; }
        public int EmployeeID { get; set; }
        public string Weightage { get; set; }
        public int DesignationID { get; set; }
    }
}
