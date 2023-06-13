using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IEmployeeAddressRepository
    {
        Task<IEnumerable<EmployeeAddress>> GetEmployeeAddress();
        //int CreateEmployeeAddress(int EmployeeAddressID, int EmployeeID, int AddressTypeID, string AddressName, int Designation, string CreatedBy);
    }
}
