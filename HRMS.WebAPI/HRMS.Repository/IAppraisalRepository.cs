﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMS.Repository
{
    public interface IAppraisalRepository
    {
        Task<IEnumerable<Appraisal>> GetAppraisals();
    }
}
