using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resume_Shortlisting_Azure.Data;
using System.Security.Policy;

namespace Resume_Shortlisting_Azure.Controllers
{
    [Authorize(Policy = "RequireAdminRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            this._roleManager = roleManager;
        }

        [HttpPost("create-role")]
        //[Route("Create-Role")]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName));
                return Ok();
            }
            return BadRequest("Role already exists");
        }

        [HttpPost("assign-role")]
        //[Route("assign-role")]
        public async Task<IActionResult> AssignRole([FromBody] UserRoleAssignmentDto userRoleAssignment)
        {
            var user = await _userManager.FindByIdAsync(userRoleAssignment.UserId);
            if (user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, userRoleAssignment.Role);
                if (result.Succeeded)
                {
                    return Ok();
                }
                return BadRequest(result.Errors);
            }
            return NotFound();
        }
    }

    public class UserRoleAssignmentDto
    {
        public string UserId { get; set; }
        public string Role { get; set; }
    }
}

    
    

