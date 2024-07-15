using MediatR;

namespace Resume_Shortlisting_Azure.Features.Command
{
    public class DeleteRecruiterUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}
