using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IOrganisationRepository
    {
        Task<IEnumerable<Organisation>> GetOrganisations();
        //int CreateOrganisation(string OrganisationName,string OrganisationCode,string ContactPerson1,string MobileNumber1,
        //    string Email1,string ContactPerson2,string MobileNumber2,string Email2,string CountryCode,string PhoneNo,string Extn,
        //    string FaxNo,string Address,string CorrespondenceAddress,string City,string Country,string PinCode,string Email,
        //    string Website,string Remark,string CreatedBy);
    }
}
