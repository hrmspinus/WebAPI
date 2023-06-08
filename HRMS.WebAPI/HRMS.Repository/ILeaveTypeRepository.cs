using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface ILeaveTypeRepository
    {
        Task<IEnumerable<LeaveType>> GetLeaveTypes();
        int CreateLeaveType(string LeaveTypeName, string CreatedBy);

    }
}
