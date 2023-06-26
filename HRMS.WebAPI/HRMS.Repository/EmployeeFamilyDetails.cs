using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class EmployeeFamilyDetails
    {
        public int EmployeeFamilyDetailID { get; set; }
        public int EmployeeID { get; set; }
        public string? Name { get; set; }
        public string? RelationShip { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public string? ContactNo { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
