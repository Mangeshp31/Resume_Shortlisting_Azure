using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resume_Shortlisting_Azure.Data;
using Resume_Shortlisting_Azure.Features;
using Resume_Shortlisting_Azure.Features.Command;
using Resume_Shortlisting_Azure.Features.Query;
using Resume_Shortlisting_Azure.Models.DTOs;

namespace Resume_Shortlisting_Azure.Controllers
{
    //[Authorize(Policy ="RequireEmployeeRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeController(IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> CreateEmployeeUser([FromBody] EmployeeUserDto employeeUserDto)
        {
            //byte[] text = employeeUserDto.Resume;
            var userId = _userManager.GetUserId(User);
            var command = new CreateEmployeeUserCommand { EmployeeUserDto = employeeUserDto, UserId = userId };
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetEmployeeUserById), new { id = id }, id);
        }

        [HttpGet("{id}")]
        //[Route("GetByIdEmployee")]
        public async Task<IActionResult> GetEmployeeUserById(int id)
        {
            var userId = _userManager.GetUserId(User);
            var query = new GetEmployeeUserByIdQuery { Id = id, UserId = userId };
            var employeeUserDto = await _mediator.Send(query);
            if (employeeUserDto == null)
            {
                return NotFound();
            }
            return Ok(employeeUserDto);
        }


        [HttpPut("{id}")]
        //[Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployeeUser(int id, [FromBody] EmployeeUserDto employeeUserDto)
        {
            var userId = _userManager.GetUserId(User);
            var command = new UpdateEmployeeUserCommand { Id = id, EmployeeUserDto = employeeUserDto, UserId = userId };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Route("Delete")]
        public async Task<IActionResult> DeleteEmployeeUser(int id)
        {
            var userId = _userManager.GetUserId(User);
            var command = new DeleteEmployeeUserCommand { Id = id, UserId = userId };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
