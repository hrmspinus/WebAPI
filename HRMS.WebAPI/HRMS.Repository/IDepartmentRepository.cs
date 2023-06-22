using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        int CreateDepartmentType(string DepartmentName, string CreatedBy);
        int DeleteDepartment(int DepartmentID);
        int UpdateDepartment(int DepartmentID, string DepartmentName, string CreatedBy);
    }
}
