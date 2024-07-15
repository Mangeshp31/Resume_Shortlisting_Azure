using MediatR;
using Resume_Shortlisting_Azure.Models.DTOs;

namespace Resume_Shortlisting_Azure.Features.Query
{
    public class GetRecruiterUsersQuery : IRequest<IEnumerable<RecruiterUserDto>>
    {
    }
}
