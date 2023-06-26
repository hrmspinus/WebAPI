using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class EmployeeQualification
    {
        public int EmployeeQualificationID { get; set; }
        public int EmployeeID { get; set; }
        public string? DegreeName { get; set; }
        public string? instituteName { get; set; }
        public string? UniversityName { get; set; }
        public string? YearOfPassing { get; set; }
        public int Percentage { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
