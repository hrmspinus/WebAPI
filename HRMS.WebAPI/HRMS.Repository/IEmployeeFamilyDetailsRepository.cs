using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IEmployeeFamilyDetailsRepository
    {
        Task<IEnumerable<EmployeeFamilyDetails>> GetEmployeeFamilyDetails();
        int CreateEmployeeFamilyDetails(int EmployeeID, string Name, string RelationShip, int Age, DateTime DOB, string ContactNo, 
            string CreatedBy, string ModifiedBy);
    }
}
