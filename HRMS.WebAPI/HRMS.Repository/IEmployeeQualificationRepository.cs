using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IEmployeeQualificationRepository 
    {
        Task<IEnumerable<EmployeeQualification>> GetEmployeeQualifications(int EmployeeQualificationID);
        Task<IEnumerable<EmployeeQualification>> GetAllEmployeeQualifications();
        int CreateEmployeeQualifications(EmployeeQualification empQualifications);
        Task<IEnumerable<EmployeeQualification>> GetDeleteEmployeeQualifications(int EmployeeQualificationID);
        //int DeleteEmployeeDetails(EmployeeDetails empDetails);
    }
}
