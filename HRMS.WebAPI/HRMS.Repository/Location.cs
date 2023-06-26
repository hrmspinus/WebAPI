using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public class Location
    {
        public int LocationID { get; set; }
        public string? LocationName { get; set; }
        public string? CreatedBy { get; set; }
    }
}
