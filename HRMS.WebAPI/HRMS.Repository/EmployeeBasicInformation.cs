using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class EmployeeBasicInformation
    {
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string WorkStatus { get; set; }
        public string HomeAddress { get; set; }
        public string CityOfBirth { get; set; }
        public string CountryOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public DateTime WeddingDate { get; set; }
        public string PrimaryNationality { get; set; }
    }
}
