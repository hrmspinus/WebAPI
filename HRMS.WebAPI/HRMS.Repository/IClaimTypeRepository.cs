using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IClaimTypeRepository
    {
        Task<IEnumerable<ClaimType>> GetClaimTypes();
        int CreateClaimType(string ClaimTypeName, string CreatedBy);
        int DeleteClaimType(int ClaimTypeID);
        int UpdateClaimType(int ClaimTypeID, string ClaimTypeName, string CreatedBy);
    }
}
