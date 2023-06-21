﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IAppraisalObjectivesRepository
    {
        Task<IEnumerable<AppraisalObjectives>> GetAppraisals();
        int CreateAppraisalObjectives(string AppraisalName, string CreatedBy);
    }
}
