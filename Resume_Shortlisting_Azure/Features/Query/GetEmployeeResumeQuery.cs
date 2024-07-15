using MediatR;

namespace Resume_Shortlisting_Azure.Features.Query
{
    public class GetEmployeeResumeQuery : IRequest<byte[]>
    {
        public int Id { get; set; }
    }
}
