using MediatR;

namespace Resume_Shortlisting_Azure.Features.Command
{
    public class DeleteEmployeeUserCommand : IRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; }
    }
}
