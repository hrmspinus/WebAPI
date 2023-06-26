using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class EmployeeExperience
    {
		public int EmployeeExperienceID { get; set; }
        public int EmployeeID { get; set; }
        public string? CompanyName { get; set; }
        public string? Designation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int YearsWorked { get; set; }
        public int Salary { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
        
    }
}
