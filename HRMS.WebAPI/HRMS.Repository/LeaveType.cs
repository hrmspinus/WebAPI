using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class LeaveType
    {
        public int LeaveTypeId { get; set; }

        public string? LeaveTypeName { get; set; }
        public string? CreatedBy { get; set; }
    }
}
