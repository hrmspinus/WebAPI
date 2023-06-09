﻿using HRMS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HrmsRoleController : ControllerBase
    {
        private readonly ILogger<HrmsRoleController> _logger;
        private IHrmsRoleRepository _hrmsrolerepo;
        public HrmsRoleController(ILogger<HrmsRoleController> logger, IHrmsRoleRepository hrmsrolerepo)
        {
            _logger = logger;
            _hrmsrolerepo = hrmsrolerepo;
        }

        [HttpGet(Name = "GetHrmsRoles")]
        public Task<IEnumerable<HrmsRole>> GetHrmsRoles()
        {
            return _hrmsrolerepo.GetHrmsRoles();

        }

        [HttpPost(Name = "CreateHrmsRole")]
        public int CreateHrmsRole(HrmsRole hrmsRole)
        {
            return _hrmsrolerepo.CreateHrmsRole(hrmsRole.RoleName, hrmsRole.CreatedBy);

        }

        [HttpDelete(Name = "DeleteHrmsRole")]
        public int DeleteHrmsRole(int RoleID)
        {
            return _hrmsrolerepo.DeleteHrmsRole(RoleID);
        }

        [HttpPut(Name = "UpdateHrmsRole")]
        public int UpdateHrmsRole(HrmsRole hrmsRole)
        {
            return _hrmsrolerepo.UpdateHrmsRole(hrmsRole.RoleID,hrmsRole.RoleName, hrmsRole.CreatedBy);
        }
    }
}
