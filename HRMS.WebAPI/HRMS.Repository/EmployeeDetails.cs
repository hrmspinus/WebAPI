using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class EmployeeDetails
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; } 
        public string MiddleName { get; set; } 
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string EmergencyContactNumber { get; set; }
        public string Location { get; set; }
        public string MaritalStatus { get; set; }

    }
}
