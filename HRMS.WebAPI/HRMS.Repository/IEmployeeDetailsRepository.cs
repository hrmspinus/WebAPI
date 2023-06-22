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
        int CreateEmployeeDetails(string FirstName,string MiddleName,string LastName,DateTime DateOfBirth,int Age,string Gender,
            string Email,string PhoneNumber,string EmergencyContactNumber,string Location,string MaritalStatus);
    }
}
