using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IEmployeeExperienceRepository
    {
        Task<IEnumerable<EmployeeExperience>> GetEmployeeExperiences();
        int CreateEmployeeExperiences(int EmployeeID, string CompanyName, string Designation,DateTime StartDate, 
            DateTime EndDate, int YearsWorked, int Salary,string CreatedBy, string ModifiedBy);
    }
}
