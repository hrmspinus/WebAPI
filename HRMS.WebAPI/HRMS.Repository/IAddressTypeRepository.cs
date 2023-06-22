using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IAddressTypeRepository
    {
        Task<IEnumerable<AddressType>> GetAddressTypes();
        int CreateAddressType(string AddressTypeName, string CreatedBy);
        int DeleteAddressType(int AddressTypeId);
        int UpdateAddressType(int AddressTypeID, string AddressTypeName, string CreatedBy);
    }
}
