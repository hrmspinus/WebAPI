using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IEmployeeDetailsRepository
    {
        Task<IEnumerable<EmployeeDetails>> GetEmployeeDetails();
        int CreateEmployeeDetails(int OrganisationID, int AutoNumber, string FirstName, string MiddleName, string LastName, 
            DateTime DateOfBirth,int Age, string Gender, string Email, string PhoneNumber, string EmergencyContactNumber, 
            string Location,string MaritalStatus, DateTime HireDate, int LengthOfService, int FTE, int ManagerID, 
            int BusinessTitleID,int DepartmentID,int DesignationID, int BloodGroupID, string CreatedBy, string ModifiedBy);
    }
}
