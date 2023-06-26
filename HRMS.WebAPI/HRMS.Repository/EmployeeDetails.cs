using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class EmployeeDetails
    {
        public int EmployeeID { get; set; }
        public int OrganisationID { get; set; }
        public int AutoNumber { get; set; }
        public string? FirstName { get; set; } 
        public string? MiddleName { get; set; } 
        public string? LastName { get; set; }
        public string? EmployeeName { get; set; }
        public string? DateOfBirth { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmergencyContactNumber { get; set; }
        public string? Location { get; set; }
        public string? MaritalStatus { get; set; }
        public string? HireDate { get; set; }
        public int ManagerID { get; set; }
        public string? ManagerName { get; set; }
        public int BusinessTitleID { get; set; }
        public int DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
        public int DesignationID { get; set; }
        public string? DesignationName { get; set; }
        public int BloodGroupID { get; set; }
        public string? BloodGroupName { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }

    }
}
