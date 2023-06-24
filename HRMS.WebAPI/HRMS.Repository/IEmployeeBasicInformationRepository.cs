using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IEmployeeBasicInformationRepository
    {
        Task<IEnumerable<EmployeeBasicInformation>> GetEmployeeBasicInformations();
        int CreateEmployeeBasicInformation(string Name,string FatherName,DateTime DateOfBirth,int Age,string Gender,string PhoneNo,
            string Email,string HomeAddress, string CityOfBirth,string CountryOfBirth,string MaritalStatus,DateTime WeddingDate,
            string PrimaryNationality);
    }
}
