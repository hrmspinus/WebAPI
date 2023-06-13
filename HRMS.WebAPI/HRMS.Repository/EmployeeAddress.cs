using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class EmployeeAddress
    {
        public int EmployeeAddressID { get; set; }
        public int EmployeeID { get; set; }   
        public int AddressTypeID { get; set; }
        public string AddressName { get; set; }
        public int DesignationID { get; set; }
        public string CreatedBy { get; set; }
    }
}
