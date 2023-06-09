using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class Organisation
    {
        public int OrganisationID { get; set; }
        public string OrganisationName { get; set; } 
        public string OrganisationCode { get; set; }
        public int AutoNumber { get; set; }
        public string ContactPerson1 { get; set; }
        public string MobileNumber1 { get; set; }
        public string Email1 { get; set; }
        public string ContactPerson2 { get; set; }
        public string MobileNumber2 { get; set; }
        public string Email2 { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNo { get; set; }
        public string Extn { get; set; }
        public string FaxNo { get; set; }
        public string Address { get; set; }
        public string CorrespondenceAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
    }
}
