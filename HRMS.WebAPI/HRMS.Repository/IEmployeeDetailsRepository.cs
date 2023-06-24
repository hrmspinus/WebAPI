using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IEmployeeDetailsRepository
    {
        Task<IEnumerable<EmployeeDetails>> GetEmployeeDetails(int EmployeeID);
        Task<IEnumerable<EmployeeDetails>> GetAllEmployeeDetails();
        int CreateEmployeeDetails(EmployeeDetails empDetails);
    }
}
