using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resume_Shortlisting_Azure.Features;
using Resume_Shortlisting_Azure.Features.Command;
using Resume_Shortlisting_Azure.Features.Query;

namespace Resume_Shortlisting_Azure.Controllers
{
    [Authorize(Policy = "RequireRecruiterRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecruiterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        //[Route("Search")]
        public async Task<IActionResult> SearchResumes([FromQuery] string skills, [FromQuery] string location, [FromQuery] string technologyDomain)
        {
            var query = new SearchResumesQuery { Skills = skills, Location = location, TechnologyDomain = technologyDomain };
            var employeeUsers = await _mediator.Send(query);
            return Ok(employeeUsers);
        }

        [HttpGet("{id}/resume")]
        //[Route("GetResume")]
        public async Task<IActionResult> GetEmployeeResume(int id)
        {
            var query = new GetEmployeeResumeQuery { Id = id };
            var resume = await _mediator.Send(query);
            if (resume == null)
            {
                return NotFound();
            }

            return File(resume, "application/octet-stream", "resume.pdf");
        }

        [HttpDelete("{id}")]
        //[Route("Delete")]
        public async Task<IActionResult> DeleteRecruiterUser(int id)
        {
            var command = new DeleteRecruiterUserCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("recruiters")]
        //[Route("GetRecruiterUsers")]
        public async Task<IActionResult> GetRecruiterUsers()
        {
            var query = new GetRecruiterUsersQuery();
            var recruiterUsers = await _mediator.Send(query);
            return Ok(recruiterUsers);
        }
    }
}
