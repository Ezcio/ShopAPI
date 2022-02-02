using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sklep.Services;
using Sklep.Entities;
using Sklep.Services.RoleService;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sklep.Models;

namespace Sklep.Controllers
{
    [ApiController]
    [Route("api/role/")]
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleService _roleService;


        public RoleController(ILogger<RoleController> logger, IRoleService roleService)
        {
            _logger = logger;
            _roleService = roleService;
        }



        [HttpPost("CreateRole/{roleName}")]
        public async Task<ActionResult> CreateRole(string roleName)
        {
            await _roleService.CreateRole(roleName);

            return NoContent();   
        }

        [HttpPost("GetRoleById/{id}")]
        public async Task<ActionResult<string>> GetRoleById(int id)
        {
            var response = await _roleService.GetRoleById(id);

            return Ok(JsonSerializer.Serialize(response));

        }
        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<string>> GetAllRoles()
        {
            var result = await _roleService.GetAllRoles();
            return Ok(JsonSerializer.Serialize(result));
        }
    }     
}

//Get country by id