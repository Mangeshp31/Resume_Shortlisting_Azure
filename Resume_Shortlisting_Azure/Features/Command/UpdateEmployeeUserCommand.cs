using MediatR;
using Resume_Shortlisting_Azure.Models.DTOs;

namespace Resume_Shortlisting_Azure.Features.Command
{
    public class UpdateEmployeeUserCommand : IRequest
    {
        public int Id { get; set; }
        public EmployeeUserDto EmployeeUserDto { get; set; }
        public string UserId { get; set; }

    }
}
